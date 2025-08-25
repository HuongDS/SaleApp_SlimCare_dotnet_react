export type User = {
  Id: number;
  Username: string;
  Email: string;
  Role: string;
};

export type ResponseDto = {
  AccessToken: string;
  RefreshToken: string;
  ExpiresIn: number;
  User: User;
  Role: string;
};
