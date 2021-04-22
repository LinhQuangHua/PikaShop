import React from "react";
import { Link } from "react-router-dom";
import axios from 'axios';
import IUser from "../../interface/IUser";
import { Table, Button } from 'reactstrap';

export default class User extends React.Component {
  state = {
    cates: []
  }

  componentDidMount() {
    axios.get(`https://pikashop.azurewebsites.net/api/user`)
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
        <h3>List Users</h3>
        <Table>
          <thead>
            <tr>
              <th>ID User</th>
              <th>Email</th>
              <th>Phone Number</th>
            </tr>
          </thead>
          {this.state.cates.map((cates: IUser) =>
            <tbody key={cates.id_user}>
              <tr>
                <th scope="row">{cates.id_user}</th>
                <td>{cates.mail_user}</td>
                <td>{cates.phone}</td>
              </tr>
            </tbody>)}
        </Table>
        <Button color="warning"><Link to="/">Return Home</Link></Button>
      </>

    )
  }
}
