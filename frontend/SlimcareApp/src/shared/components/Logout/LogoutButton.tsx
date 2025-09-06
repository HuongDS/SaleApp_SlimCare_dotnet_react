import { Button } from "react-bootstrap";
import { getRefreshToken } from "../../../token/tokenStore";
import { logout } from "../../../services/authService";
import { logoutRedux } from "../../../redux/authSlice";
import {
  useDispatch,
  useSelector,
} from "react-redux";
import type {
  AppDispatch,
  RootState,
} from "../../../redux/store";
import Cart from "../Cart/Cart";

export default function LogoutButton() {
  const refreshToken = getRefreshToken();
  const user = useSelector(
    (state: RootState) => state.auth.user
  );
  const dispatch = useDispatch<AppDispatch>();

  return (
    <>
      <h5 className="me-3">
        Welcome {user?.username}
      </h5>
      <Cart></Cart>
      <Button
        variant="outline-danger"
        size="sm"
        onClick={() => {
          logout(refreshToken);
          dispatch(logoutRedux());
        }}
      >
        Log Out
      </Button>
    </>
  );
}
