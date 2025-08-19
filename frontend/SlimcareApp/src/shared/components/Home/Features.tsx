import { Nav } from "react-bootstrap";

export default function Features() {
  return (
    <Nav className="mx-auto align-items-center fs-4">
      <Nav.Link href="#feature1">Home</Nav.Link>
      <Nav.Link href="#feature2">
        About Us
      </Nav.Link>
      <Nav.Link href="#feature3">
        Shopping
      </Nav.Link>
    </Nav>
  );
}
