import React from "react";
import { Link } from "react-router-dom";
import axios from 'axios';
import IProduct from "../../interface/IProduct";
import { Table, Button } from 'reactstrap';
import PostProduct from './PostProduct';

export default class Product extends React.Component {
  state = {
    cates: []
  }

  componentDidMount() {
    axios.get(`https://pikashop.azurewebsites.net/api/product`)
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
                <td><img src={"https://pikashop.azurewebsites.net/" + cates.ThumbnailImageUrl} style={{ width: 100, height: 100 }} alt="Product_image"></img></td>
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
        <PostProduct />
        <Button color="warning"><Link to="/">Return Home</Link></Button>
      </>

    )
  }
}
