import React from "react";
import { Link } from "react-router-dom";
import { Nav, NavItem, NavLink, Button, Row, Col } from 'reactstrap';
import './style.css';
import MenuBackground from "../background/MenuBackground.png";

const Home = () => {

  return (
    <>s
      <Row>
        <Col xs="2">
          <Nav vertical className="menu" style={{ backgroundImage: `url(${MenuBackground})` }}>
            <h3>Admin page</h3>
            <NavItem>
              <NavLink><Link to="/about"><Button className="link" color="primary">About</Button></Link></NavLink>
            </NavItem>
            <NavItem>
              <NavLink><Link to="/user"><Button className="link" color="info">User</Button></Link></NavLink>
            </NavItem>
            <NavItem>
              <NavLink><Link to="/brand"><Button className="link" color="warning">Brand</Button></Link></NavLink>
            </NavItem>
            <NavItem>
              <NavLink><Link to="/category"><Button className="link" color="danger">Category</Button></Link></NavLink>
            </NavItem>
            <NavItem>
              <NavLink><Link to="/product"><Button className="link" color="secondary">Product</Button></Link></NavLink>
            </NavItem>
          </Nav>
        </Col>
        <Col xs="10">
        </Col>
      </Row>
    </>
  )

};

export default Home;
