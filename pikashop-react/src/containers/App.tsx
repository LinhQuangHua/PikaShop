import React from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import Home from "../components/Home";
import About from "../components/About";
import User from "../components/user/User";
import Product from "../components/product/Product";
import Brand from "../components/brand/Brand";
import Category from "../components/category/Category";
import NavMenu from "./NavMenu";
import Auth from "./Auth";

const App = () => {
  return (
    <BrowserRouter basename={"/"}>
      <NavMenu />
      <div className="container">
        <Switch>
          <Route path="/authentication/:action" component={Auth} />
          <Route path="/category" component={Category} />
          <Route path="/brand" component={Brand} />
          <Route path="/product" component={Product} />
          <Route path="/user" component={User} />
          <Route path="/about" component={About} />
          <Route path="/" component={Home} />
        </Switch>
      </div>
    </BrowserRouter>
  );
};

export default App;
