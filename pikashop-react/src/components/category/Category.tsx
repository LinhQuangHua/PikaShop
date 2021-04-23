import React from "react";
import { Link } from "react-router-dom";
import axios from 'axios';
import ICategory from "../../interface/ICategory";
import { Table, Button } from 'reactstrap';
import PostCategory from "./PostCategory";
import Delete from "../../services/Delete";

export default class Category extends React.Component {
  state = {
    cates: []
  }

  componentDidMount() {
    axios.get(`https://pikashop.azurewebsites.net/api/category`)
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
        <h3>List Categories</h3>
        <Table>
          <thead>
            <tr>
              <th>ID</th>
              <th>Name</th>
            </tr>
          </thead>
          {this.state.cates.map((cates: ICategory) =>
            <tbody key={cates.id_category}>
              <tr>
                <th scope="row">{cates.id_category}</th>
                <td>{cates.name_category}</td>
                <td><Button color="primary">Edit</Button> <Button color="danger" component={Delete}>Delete</Button></td>
              </tr>
            </tbody>)}
        </Table>
        <PostCategory />
        <Button color="warning"><Link to="/">Return Home</Link></Button>
      </>
    )
  }
}
