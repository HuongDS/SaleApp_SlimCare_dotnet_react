import { useState } from "react";
import {
    clearTokens,
    getRefreshToken,
} from "../../token/tokenStore";

const API_BASE = import.meta.env.VITE_API_BASE as
    | string
    | undefined;

function joinUrl(base: string, path: string) {
    return `${base.replace(
        /\/+$/,
        ""
    )}/${path.replace(/^\/+/, "")}`;
}

export default function LogoutButton() {
    const [loading, setLoading] = useState(false);

    const handleLogout = async () => {
        if (!API_BASE) {
            console.error(
                " VITE_API_BASE is missing in .env"
            );
            return;
        }

        setLoading(true);
        try {
            const refreshToken = getRefreshToken(); // camelCase cho khớp BE
            const url = joinUrl(API_BASE, "Logout");

            console.log("🔗 Logout URL:", url);
            console.log(
                "🔑 Refresh token exists:",
                !!refreshToken
            );

            // Gọi API revoke nếu có refreshToken
            if (refreshToken) {
                const resp = await fetch(url, {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json",
                    },
                    body: JSON.stringify({ refreshToken }), //  BE nhận đúng tên key
                });

                if (!resp.ok) {
                    const text = await resp.text();
                    console.warn(
                        `Logout failed [${resp.status}]:`,
                        text
                    );
                }
            } else {
                console.warn(
                    " Không tìm thấy refreshToken, chỉ xóa token ở client"
                );
            }
        } catch (err) {
            console.error("❌ Logout error:", err);
        } finally {
            clearTokens(); // Xóa token ở client
            setLoading(false);
            alert("Đã đăng xuất");
            // window.location.href = "/"; // điều hướng nếu muốn
        }
    };

    return (
        <button
            onClick={handleLogout}
            disabled={loading}
        >
            {loading
                ? "Logging Out..."
                : "Logout"}
        </button>
    );
}
