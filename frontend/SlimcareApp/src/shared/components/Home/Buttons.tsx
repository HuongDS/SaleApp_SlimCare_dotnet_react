import { Button } from "react-bootstrap";

export default function Buttons() {
  return (
    <div className="d-flex gap-2 ms-lg-auto align-items-center">
      <Button variant="outline-primary" size="lg">
        Login
      </Button>
      <Button variant="primary" size="lg">
        Sign-up
      </Button>
    </div>
  );
}
