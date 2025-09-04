import { useState } from "react";
import {
  Button,
  FloatingLabel,
  Form,
  FormControl,
  Modal,
  Spinner,
} from "react-bootstrap";
import {
  loginWithPassword,
  saveTokens,
} from "../../../services/api/authService";
import type { UserLoginDto } from "../../../model/LoginModel";
import GoogleLoginButton from "../Home/GoogleLoginButton";
import { useDispatch } from "react-redux";
import { loginSuccess } from "../../../redux/authSlice";
import type { AppDispatch } from "../../../redux/store";

export default function LoginForm() {
  const dispatch = useDispatch<AppDispatch>();
  const [showLoginForm, setShowLoginForm] =
    useState(false);
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [submitting, setSubmitting] =
    useState(false);
  const [error, setError] = useState<
    string | null
  >(null);

  const userLoginData: UserLoginDto = {
    Username: username,
    Password: password,
  };

  async function handleLoginSubmit(
    e: React.FormEvent<HTMLFormElement>
  ) {
    e.preventDefault();

    setError(null);

    try {
      setSubmitting(true);
      const data = await loginWithPassword(
        userLoginData
      );
      dispatch(loginSuccess(data.user));
      setUsername("");
      setPassword("");
      saveTokens(
        data.AccessToken,
        data.RefreshToken
      );
    } catch (err) {
      console.log("Error: ", err);
      setError("Something went wrong!");
      console.log("Error: ", error);
    } finally {
      setSubmitting(false);
    }
  }

  return (
    <>
      <Button
        variant="outline-primary"
        size="lg"
        onClick={() => setShowLoginForm(true)}
      >
        Login
      </Button>
      <Modal
        show={showLoginForm}
        onHide={() => setShowLoginForm(false)}
      >
        <Modal.Header>
          <Modal.Title>Log In</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form
            id="loginForm"
            onSubmit={handleLoginSubmit}
          >
            <FloatingLabel
              controlId="floatingInput"
              label="Username"
              className="mb-3"
            >
              <FormControl
                type="text"
                placeholder="Enter your username"
                value={username}
                onChange={(e) =>
                  setUsername(e.target.value)
                }
                required
                disabled={submitting}
              />
            </FloatingLabel>
            <FloatingLabel
              controlId="floatingPassword"
              label="Password"
              className="mb-3"
            >
              <FormControl
                type="password"
                placeholder="Enter password"
                value={password}
                onChange={(e) =>
                  setPassword(e.target.value)
                }
                required
                disabled={submitting}
              />
            </FloatingLabel>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button
            variant="secondary"
            onClick={() =>
              setShowLoginForm(false)
            }
            disabled={submitting}
          >
            Close
          </Button>
          <Button
            variant="primary"
            onClick={() =>
              setShowLoginForm(false)
            }
            disabled={submitting}
            type="submit"
            form="loginForm"
          >
            {submitting ? (
              <Spinner
                size="sm"
                animation="border"
              ></Spinner>
            ) : (
              "Log In"
            )}
          </Button>
          <GoogleLoginButton></GoogleLoginButton>
        </Modal.Footer>
      </Modal>
    </>
  );
}
