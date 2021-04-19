import React from 'react';

import axios from 'axios';
import IPerson from '../interface/IPerson'
import { Link } from "react-router-dom";

// export interface IPerson{
//   username:string
// }
export default class About extends React.Component {
  state = {
    persons: []
  }

  componentDidMount() {
    axios.get(`https://jsonplaceholder.typicode.com/users`)
      .then(res => {
        const persons = res.data;
        this.setState({ persons });
      })
      .catch(error => console.log(error));
  }

  render() {
    return (
      <>
        <h3>List User</h3>
        <ul>
          {this.state.persons.map((person: IPerson) => <li>{person.username}</li>)}
        </ul>
        <Link to="/">Return Home</Link>
      </>

    )
  }
}
