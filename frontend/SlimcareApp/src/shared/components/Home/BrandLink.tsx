import { Image } from "react-bootstrap";
import Container from "react-bootstrap/esm/Container";
import Navbar from "react-bootstrap/esm/Navbar";
import { Link } from "react-router-dom";

export default function BrandLink() {
  return (
    <Navbar>
      <Container>
        <Navbar.Brand as={Link} to="/">
          <Image
            src="/public/images/logo-remove-bg.png"
            width={60}
            height={60}
            roundedCircle
          />
        </Navbar.Brand>
      </Container>
    </Navbar>
  );
}
