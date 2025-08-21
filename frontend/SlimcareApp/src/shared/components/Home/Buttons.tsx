import { useState } from "react";
import {
  Button,
  FloatingLabel,
  Form,
  FormControl,
  Modal,
} from "react-bootstrap";

export default function Buttons() {
  const [show, setShow] = useState(false);

  return (
    <div className="d-flex gap-2 ms-lg-auto align-items-center">
      <Button
        variant="outline-primary"
        size="lg"
        onClick={() => setShow(true)}
      >
        Login
      </Button>
      <Modal
        show={show}
        onHide={() => setShow(false)}
      >
        <Modal.Header>
          <Modal.Title>Log In</Modal.Title>
        </Modal.Header>
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
                required
              />
            </FloatingLabel>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button
            variant="secondary"
            onClick={() => setShow(false)}
          >
            Close
          </Button>
          <Button
            variant="primary"
            onClick={() => setShow(false)}
          >
            Log In
          </Button>
        </Modal.Footer>
      </Modal>