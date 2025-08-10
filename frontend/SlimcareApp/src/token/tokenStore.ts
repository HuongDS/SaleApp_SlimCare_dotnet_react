const ACCESS_KEY = "sc_access_token";
const REFRESH_KEY = "sc_refresh_token";

export function setTokens(
  accessToken: string,
  refreshToken?: string
) {
  sessionStorage.setItem(ACCESS_KEY, accessToken);
  if (refreshToken)
    localStorage.setItem(
      REFRESH_KEY,
      refreshToken
    );
}

export function getAccessToken(): string | null {
  return sessionStorage.getItem(ACCESS_KEY);
}

export function getRefreshToken(): string | null {
  return localStorage.getItem(REFRESH_KEY);
}

export function clearTokens() {
  sessionStorage.removeItem(ACCESS_KEY);
  localStorage.removeItem(REFRESH_KEY);
}

export function isLoggedIn() {
  return !!getAccessToken();
}
