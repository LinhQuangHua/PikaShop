import React from "react";
import { Link } from "react-router-dom";
import axios from 'axios';
import ICategory from "../../interface/ICategory";

// const Category = () => {
//   return (
//     <>
//       <h3>List Categories</h3>
//       <Link to="/">Return Home</Link>
//     </>
//   )

// };

// export default Category;

export default class Category extends React.Component {
  state = {
    cates: []
  }

  componentDidMount() {
    axios.get(`https://localhost:44317/api/category`)
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
        <ul>
          {this.state.cates.map((cates: ICategory) => <li key={cates.id_category}>{cates.name_category}</li>)}
        </ul>
        <Link to="/">Return Home</Link>
      </>

    )
  }
}
