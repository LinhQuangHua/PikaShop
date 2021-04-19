import React from "react";
import { Link } from "react-router-dom";
import axios from 'axios';
import IProduct from "../../interface/IProduct";
import { Table, Button } from 'reactstrap';

export default class Brand extends React.Component {
  state = {
    cates: []
  }

  componentDidMount() {
    axios.get(`https://localhost:44317/api/product`)
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
        <h3>List Products</h3>
        <Table>
          <thead>
            <tr>
              <th>ID</th>
              <th>Name</th>
              <th>Image</th>
              <th>Price</th>
              <th>Height</th>
              <th>Weight</th>
              <th>Quantity</th>
              <th>Description</th>
              <th>Brand</th>
              <th>Category</th>
            </tr>
          </thead>
          {this.state.cates.map((cates: IProduct) =>
            <tbody key={cates.id_product}>
              <tr>
                <th scope="row">{cates.id_product}</th>
                <td>{cates.name_product}</td>
                <td><img src={"https://localhost:44317/user-content/"+cates.ThumbnailImageUrl} style={{ width: 100, height: 100 }}></img></td>
                <td>{cates.price}</td>
                <td>{cates.height}</td>
                <td>{cates.weight}</td>
                <td>{cates.quantity}</td>
                <td>{cates.description}</td>
                <td>{cates.name_brand}</td>
                <td>{cates.name_category}</td>
              </tr>
            </tbody>)}
        </Table>
        <Button color="warning"><Link to="/">Return Home</Link></Button>
      </>

    )
  }
}
