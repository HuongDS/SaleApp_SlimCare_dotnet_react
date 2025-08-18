import { Image } from "react-bootstrap";
import Container from "react-bootstrap/esm/Container";
import Navbar from "react-bootstrap/esm/Navbar";

export default function BrandLink() {
  return (
    <Navbar>
      <Container>
        <Navbar.Brand href="#home">
          <Image
            src="/images/logo-remove-bg.png"
            width={60}
            height={60}
            roundedCircle
          />
        </Navbar.Brand>
      </Container>
    </Navbar>
  );
}
