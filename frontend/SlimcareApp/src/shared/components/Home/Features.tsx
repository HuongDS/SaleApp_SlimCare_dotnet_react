import { Nav } from "react-bootstrap";

export default function Features() {
  return (
    <Nav className="mx-auto align-items-center fs-4">
      <Nav.Link href="#feature1">
        Feature 1
      </Nav.Link>
      <Nav.Link href="#feature2">
        Feature 2
      </Nav.Link>
      <Nav.Link href="#feature3">
        Feature 3
      </Nav.Link>
    </Nav>
  );
}
