import { useState } from "react";
import {
    Button,
    FloatingLabel,
    Form,
    FormControl,
    Modal,
} from "react-bootstrap";
import LoginForm from "../Login/LoginForm";

export default function Buttons() {
    const [showSignUpForm, setShowSignUpForm] =
        useState(false);

    return (
        <div className="d-flex gap-2 ms-lg-auto align-items-center">
            <LoginForm></LoginForm>
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
                    <Form>
                        <FloatingLabel
                            controlId="floatingInput"
                            label="Username"
                            className="mb-3"
                        >
                            <FormControl
                                type="text"
                                placeholder="Enter your username"
                                required
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
                                required
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
                                required
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
                                required
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
                    >
                        Close
                    </Button>
                    <Button
                        variant="primary"
                        onClick={() =>
                            setShowSignUpForm(false)
                        }
                    >
                        Sign Up
                    </Button>
                </Modal.Footer>
            </Modal>
        </div>
    );
}
