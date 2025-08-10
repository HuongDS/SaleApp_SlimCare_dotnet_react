import GoogleLoginButton from "./components/GoogleLoginButton";
import LogoutButton from "./components/LogoutButton";

export default function App() {
  return (
    <div style={{ padding: 24 }}>
      <h1>Slimcare — Google Login</h1>
      <p style={{ color: "#666" }}>
        CLIENT ID:{" "}
        {import.meta.env.VITE_GOOGLE_CLIENT_ID
          ? "OK"
          : "MISSING!"}
      </p>
      <p style={{ color: "#666" }}>
        API BASE:{" "}
        {import.meta.env.VITE_API_BASE ||
          "MISSING!"}
      </p>
      <GoogleLoginButton />
      <LogoutButton />
    </div>
  );
}
