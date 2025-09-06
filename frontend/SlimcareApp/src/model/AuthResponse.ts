export type User = {
  Id: number;
  username: string;
  Email: string;
  Role: string;
  Password: string;
};

export type ResponseDto = {
  accessToken: string;
  refreshToken: string;
  ExpiresIn: number;
  user: User;
  Role: string;
};

export type RefreshTokenDto = {
  RefreshToken: string | null;
};
