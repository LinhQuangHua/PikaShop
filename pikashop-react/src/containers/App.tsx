import React from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import Home from "../components/Home";
import User from "../components/user/User";
import Product from "../components/product/Product";
import Brand from "../components/brand/Brand";
import Category from "../components/category/Category";
import NavMenu from "./NavMenu";
import Auth from "./Auth";
import background from "../background/placeholder.png";

const App = () => {
  return (
    <BrowserRouter basename={"/"}>
      <NavMenu />
      <div className="container-fluid" style={{ backgroundImage: `url(${background})` }}>
        <Switch>
          <Route path="/authentication/:action" component={Auth} />
          <Route path="/category" component={Category} />
          <Route path="/brand" component={Brand} />
          <Route path="/product" component={Product} />
          <Route path="/user" component={User} />
          <Route path="/" component={Home} />
        </Switch>
      </div>
    </BrowserRouter>
  );
};

export default App;
