import { Nav } from "react-bootstrap";
import { Link } from "react-router-dom";

export default function Features() {
  return (
    <Nav className="mx-auto align-items-center fs-4">
      <Nav.Link as={Link} to="/">
        Home
      </Nav.Link>
      <Nav.Link as={Link} to="/about-us">
        About Us
      </Nav.Link>
      <Nav.Link as={Link} to="/shop">
        Shopping
      </Nav.Link>
    </Nav>
  );
}
