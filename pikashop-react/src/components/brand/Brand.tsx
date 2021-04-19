import React from "react";
import { Link } from "react-router-dom";
import axios from 'axios';
import IBrand from "../../interface/IBrand";

export default class Brand extends React.Component {
  state = {
    cates: []
  }

  componentDidMount() {
    axios.get(`https://localhost:44317/api/brands`)
      .then(res => {
        const cates = res.data;
        this.setState({ cates });
        console.log(cates);
      })
      .catch(error => console.log(error));
  }

  render() {
    return (
      <>
        <h3>List Brands</h3>
        <ul>
          {this.state.cates.map((cates: IBrand) => <li key={cates.Id}>{cates.Name}</li>)}
        </ul>
        <Link to="/">Return Home</Link>
      </>

    )
  }
}
