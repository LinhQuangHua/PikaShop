import React from "react";
import { Link } from "react-router-dom";
import { Nav, NavItem, NavLink } from 'reactstrap';


const Home = () => {
  return (
    <>
      <div>
        <h3>Admin page</h3>
        <Nav vertical>
          <NavItem>
            <NavLink><Link to="/about">About</Link></NavLink>
          </NavItem>
          <NavItem>
            <NavLink><Link to="/user">User</Link></NavLink>
          </NavItem>
          <NavItem>
            <NavLink><Link to="/brand">Brand</Link></NavLink>
          </NavItem>
          <NavItem>
            <NavLink><Link to="/category">Category</Link></NavLink>
          </NavItem>
          <NavItem>
            <NavLink><Link to="/product">Product</Link></NavLink>
          </NavItem>
        </Nav>
      </div>
    </>
  )

};

export default Home;
