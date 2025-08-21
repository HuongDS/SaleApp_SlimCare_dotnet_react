import type { ResponseDto } from "../../model/AuthResponse";
import type { UserLoginDto } from "../../model/LoginModel";
import {
  clearTokens,
  getRefreshToken,
} from "../../token/tokenStore";
import { api } from "./api";

// Login with username and password
export async function loginWithPassword(
  loginData: UserLoginDto
) {
  const response = await api.post<ResponseDto>(
    "/Login",
    { loginData }
  );
  return response.data;
}

// Login with Google
export async function loginWithGoogle(
  idToken: string
) {
  const response = await api.post<ResponseDto>(
    "/LoginGoogle",
    { idToken }
  );
  return response.data;
}

// Save token
export function setTokens(
  accessToken: string,
  refreshToken: string
) {
  setTokens(accessToken, refreshToken);
}

// Log out
export function logout() {
  clearTokens();
}

// Rotate Refresh Token
export async function rotateRefreshToken() {
  const oldRefreshToken = getRefreshToken();
  if (!oldRefreshToken)
    throw new Error("No refresh token available");
  const response = await api.post<ResponseDto>(
    "/RotateRefreshToken",
    { oldRefreshToken }
  );
  const accessToken = response.data.AccessToken;
  const refreshToken = response.data.RefreshToken;
  setTokens(accessToken, refreshToken);
  return response.data;
}
