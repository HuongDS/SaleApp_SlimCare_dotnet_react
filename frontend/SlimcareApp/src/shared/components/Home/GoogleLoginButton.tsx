import { useEffect, useRef } from "react";
import { setTokens } from "../../../token/tokenStore";

type GsiCredential = { credential: string };

export default function GoogleLoginButton() {
  const btnRef = useRef<HTMLDivElement>(null);

  useEffect(() => {
    if (!import.meta.env.VITE_GOOGLE_CLIENT_ID) {
      console.warn(
        "VITE_GOOGLE_CLIENT_ID is missing"
      );
    }
    if (!import.meta.env.VITE_API_BASE) {
      console.warn("VITE_API_BASE is missing");
    }

    const id = setInterval(() => {
      if (!window.google) return;
      clearInterval(id);

      window.google.accounts.id.initialize({
        client_id: import.meta.env
          .VITE_GOOGLE_CLIENT_ID,
        callback: handleCredentialResponse,
      });

      if (btnRef.current) {
        window.google.accounts.id.renderButton(
          btnRef.current,
          {
            theme: "filled_blue",
            size: "medium",
            logo_alignment: "center",
            text: "signin_with",
            shape: "rectangular",
          }
        );
      }

      // Optional: One Tap
      // window.google.accounts.id.prompt();
    }, 100);

    return () => clearInterval(id);
  }, []);

  async function handleCredentialResponse(
    resp: GsiCredential
  ) {
    try {
      const apiBase = (
        import.meta.env.VITE_API_BASE as string
      ).replace(/\/+$/, "");
      const r = await fetch(
        `${apiBase}/LoginGoogle`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            idToken: resp.credential,
          }), // BE nhận field idToken
        }
      );

      if (!r.ok) {
        const text = await r.text();
        throw new Error(
          `HTTP ${r.status} ${r.statusText} - ${text}`
        );
      }

      const data = await r.json();
      // chấp nhận cả refreshToken hoặc RefreshToken (tuỳ casing backend)
      const accessToken: string | undefined =
        data.accessToken ?? data.AccessToken;
      const refreshToken: string | undefined =
        data.refreshToken ?? data.RefreshToken;

      // lưu token (dùng tokenStore của bạn)
      if (accessToken)
        setTokens(accessToken, refreshToken);

      console.log("Backend response:", data);
      console.log(
        "Saved access:",
        sessionStorage.getItem("sc_access_token")
      );
      console.log(
        "Saved refresh:",
        localStorage.getItem("sc_refresh_token")
      );

      // thông báo cho app biết trạng thái auth đã đổi
      window.dispatchEvent(
        new Event("auth-changed")
      );
      alert("Đăng nhập thành công!");
    } catch (err) {
      console.error("Login error:", err);
      alert(
        "Google login thất bại. Mở console để xem chi tiết."
      );
    }
  }

  return (
    <div ref={btnRef} id="google-signin-button" />
  );
}
