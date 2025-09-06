export type User = {
  Id: number;
  Username: string;
  Email: string;
  Role: string;
};

export type ResponseDto = {
  accessToken: string;
  refreshToken: string;
  ExpiresIn: number;
  User: User;
  Role: string;
};

export type RefreshTokenDto = {
  RefreshToken: string | null;
};
