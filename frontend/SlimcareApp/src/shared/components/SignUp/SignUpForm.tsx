import { useState } from "react";
import type {
  UserLoginDto,
  UserSignUpDto,
} from "../../../model/LoginModel";
import {
  loginWithPassword,
  saveTokens,
  signUp,
} from "../../../services/authService";
import {
  Button,
  FloatingLabel,
  Form,
  FormControl,
  Modal,
  Spinner,
} from "react-bootstrap";

export default function SignUpForm() {
  const [showSignUpForm, setShowSignUpForm] =
    useState(false);
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [confirm, setConfirm] = useState("");
  const [email, setEmail] = useState("");
  const [error, setError] = useState<
    string | null
  >(null);
  const [submit, setSubmitting] = useState(false);

  const signUpData: UserSignUpDto = {
    Username: username,
    Password: password,
    Email: email,
    Role: "USER",
  };

  async function handleSignUpSubmit(
    e: React.FormEvent<HTMLFormElement>
  ) {
    e.preventDefault();
    setError(null);
    try {
      setSubmitting(true);
      const data = await signUp(signUpData);
      setUsername("");
      setPassword("");
      setEmail("");
      setConfirm("");
      const loginData: UserLoginDto = {
        Username: data.username,
        Password: data.Password,
      };

      const loginRes = await loginWithPassword(
        loginData
      );
      saveTokens(
        loginRes.AccessToken,
        loginRes.RefreshToken
      );
      console.log("Login Success!");
    } catch (err) {
      console.log("Error: " + error);
      setError(error);
      console.log(err);
    } finally {
      setSubmitting(false);
    }
  }

  return (
    <>
      <Button
        variant="primary"
        size="lg"
        onClick={() => setShowSignUpForm(true)}
      >
        Sign Up
      </Button>

      <Modal
        show={showSignUpForm}
        onHide={() => setShowSignUpForm(false)}
      >
        <Modal.Header>Sign Up</Modal.Header>
        <Modal.Body>
          <Form
            id="signUpForm"
            onSubmit={handleSignUpSubmit}
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
                onChange={(e) => e.target.value}
                required
                disabled={submit}
              ></FormControl>
            </FloatingLabel>
            <FloatingLabel
              controlId="floatingPassword"
              label="Password"
              className="mb-3"
            >
              <FormControl
                type="Password"
                placeholder="Enter your password"
                value={password}
                onChange={(e) => e.target.value}
                required
                disabled={submit}
              ></FormControl>
            </FloatingLabel>
            <FloatingLabel
              controlId="floatingConfirmPassword"
              label="Confirm Password"
              className="mb-3"
            >
              <FormControl
                type="Password"
                placeholder="Enter your confirm password"
                value={confirm}
                onChange={(e) => e.target.value}
                required
                disabled={submit}
              ></FormControl>
            </FloatingLabel>
            <FloatingLabel
              controlId="floatingEmail"
              label="Email"
              className="mb-3"
            >
              <FormControl
                type="email"
                placeholder="Enter your email"
                value={email}
                onChange={(e) => e.target.value}
                required
                disabled={submit}
              ></FormControl>
            </FloatingLabel>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button
            variant="secondary"
            onClick={() =>
              setShowSignUpForm(false)
            }
            disabled={submit}
          >
            Close
          </Button>
          <Button
            variant="primary"
            onClick={() =>
              setShowSignUpForm(false)
            }
            disabled={submit}
            type="submit"
            form="signUpForm"
          >
            {submit ? (
              <Spinner
                size="sm"
                animation="border"
              ></Spinner>
            ) : (
              "Sign Up"
            )}
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}
