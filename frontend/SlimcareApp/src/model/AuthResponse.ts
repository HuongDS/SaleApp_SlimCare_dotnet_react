export type User = {
  Id: number;
  username: string;
  Email: string;
  Role: string;
  Password: string;
};

export type ResponseDto = {
  AccessToken: string;
  RefreshToken: string;
  ExpiresIn: number;
  user: User;
  Role: string;
};
