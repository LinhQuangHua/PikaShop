import React from "react";
import { Link } from "react-router-dom";
import axios from 'axios';
import IBrand from "../../interface/IBrand";
import { Table, Button } from 'reactstrap';

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
              </tr>
            </tbody>)}
        </Table>
        <Button color="warning"><Link to="/">Return Home</Link></Button>
      </>

    )
  }
}
