import React from 'react';
import { Button } from 'reactstrap';
import axios from 'axios';
import IPerson from '../interface/IPerson'
import { Link } from "react-router-dom";

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
        <div className="container" style={{ backgroundColor: "#6600ff", borderRadius: 10, padding: 30, height: 650, color: "#ffffff" }}>
          <h3>List User</h3>
          <ul>
            {this.state.persons.map((person: IPerson) => <li>{person.username}</li>)}
          </ul>
          <Link to="/"><Button color="warning">Return Home</Button></Link>
        </div>
      </>

    )
  }
}
