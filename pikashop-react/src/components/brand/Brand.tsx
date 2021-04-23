import React from "react";
import { Link } from "react-router-dom";
import axios from 'axios';
import IBrand from "../../interface/IBrand";
import { Table, Button } from 'reactstrap';
import PostBrand from "./PostBrand";
import Delete from "../../services/Delete";

export default class Brand extends React.Component {
  state = {
    cates: []
  }

  constructor(props: any) {
    super(props);
    this.handleDelete = this.handleDelete.bind(this);

  }
  _fetchBrandData() {
    axios.get(`https://pikashop.azurewebsites.net/api/brands`)
      .then(res => {
        const cates = res.data;
        this.setState({ cates });
        console.log(cates);
      })
      .catch(error => console.log(error));
  }

  componentDidMount() {
    this._fetchBrandData();
  }

  handleDelete(itemId: any) {
    Delete("brands", itemId)
      .then(res => {
        this._fetchBrandData();
      }).catch(err => {
        console.log(err);
      })
  }

  render() {
    return (
      <>
        <h3>List Brands</h3>
        <Table>
          <thead>
            <tr>
              <th>ID</th>
              <th>Name</th>
            </tr>
          </thead>
          {this.state.cates.map((cates: IBrand) =>
            <tbody key={cates.Id}>
              <tr>
                <th scope="row">{cates.Id}</th>
                <td>{cates.Name}</td>
                <td><Button color="primary">Edit</Button> <Button color="danger" onClick={() => this.handleDelete(cates.Id)} >Delete</Button></td>
              </tr>
            </tbody>)}
        </Table>
        <PostBrand />
        <Button color="warning"><Link to="/">Return Home</Link></Button>
      </>

    )
  }
}
