import LoginForm from "../Login/LoginForm";
import SignUpForm from "../SignUp/SignUpForm";

export default function Buttons() {
  return (
    <div className="d-flex gap-2 ms-lg-auto align-items-center">
      <LoginForm></LoginForm>
      <SignUpForm></SignUpForm>
    </div>
  );
}
