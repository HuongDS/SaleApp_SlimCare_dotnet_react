import { useEffect, useRef } from "react";
import {
  loginWithGoogle,
  saveTokens,
} from "../../../services/api/authService";

type GsiCredential = { credential: string };

export default function GoogleLoginButton() {
  const btnRef = useRef<HTMLDivElement>(null);

  useEffect(() => {
    const id = setInterval(() => {
      // interval ở đây dùng để kiểm tra thư viện google đã được load hay chưa
      if (!window.google) return; // chưa thì thoát ra chờ interval kế tiếp
      clearInterval(id); // có rồi thì xóa interval

      // khởi tạo google identity services
      window.google.accounts.id.initialize({
        client_id: import.meta.env.VITE_GOOGLE_CLIENT_ID,
        callback: handleCredentialResponse,
      });

      if (btnRef.current) {
        window.google.accounts.id.renderButton(
          btnRef.current,
          {
            theme: "filled_blue",
            size: "medium",
            logo_alignment: "center",
            text:"signin_with",
            shape:"rectangular"
          }
        );
      }
      // Optional: One Tap
      // window.google.accounts.id.prompt();
    }, 100);

    return () => clearInterval(id);
  }, []);

  async function handleCredentialResponse(resp: GsiCredential) 
  {
    try {
      const data = await loginWithGoogle(
        resp.credential
      );
      const accessToken = data.AccessToken;
      const refreshToken = data.RefreshToken;
      saveTokens(accessToken, refreshToken);
      window.dispatchEvent(
        new Event("auth-changed")
      );
      alert("Login successfully!");
    } catch (err) {
      console.error("Login error:", err);
      alert("Login failed.");
    }
  }

  return (
    <div ref={btnRef} id="google-signin-button" />
  );
}
