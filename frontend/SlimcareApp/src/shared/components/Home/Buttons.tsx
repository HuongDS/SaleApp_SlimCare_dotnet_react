import { useSelector } from "react-redux";
import LoginForm from "../Login/LoginForm";
import SignUpForm from "../SignUp/SignUpForm";
import type { RootState } from "../../../redux/store";
import LogoutButton from "../Logout/LogoutButton";

export default function Buttons() {
  const { isAuthenticated } = useSelector(
    (state: RootState) => state.auth
  );

  return (
    <div className="d-flex gap-2 ms-lg-auto align-items-center">
      {isAuthenticated ? (
        <LogoutButton></LogoutButton>
      ) : (
        <>
          <LoginForm></LoginForm>
          <SignUpForm></SignUpForm>
        </>
      )}
    </div>
  );
}
