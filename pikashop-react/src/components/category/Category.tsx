import React from "react";
import { Link } from "react-router-dom";
import axios from 'axios';
import ICategory from "../../interface/ICategory";
import { Table, Button } from 'reactstrap';
import PostCategory from "./PostCategory";
import Delete from "../../services/Delete"
import { hostURL } from "../../config";;

export default function Category(props: any) {

  const [cates, setCates] = React.useState([]);
  const [itemSelected, setSelected] = React.useState(null);

  const _fetchCategoryData = () => {
    axios.get(hostURL + `/api/category`)
      .then(res => {
        const cates = res.data;
        setCates(cates);
        console.log(cates);
      })
      .catch(error => console.log(error));
  }

  React.useEffect(() => {
    _fetchCategoryData();
  }, [])

  const handleDelete = (itemId: any) => {
    Delete("category", itemId)
      .then(res => {
        _fetchCategoryData();
      }).catch(err => {
        console.log(err);
      })
  }

  const handleEdit = (itemEdit: any) => {
    setSelected(itemEdit);
  }

  return (
    <>
      <div className="container" style={{ backgroundColor: "#6600ff", borderRadius: 10, padding: 30, height: 650, color: "#ffffff" }}>
        <h3>List Categories</h3>
        <Table style={{ color: "#ffffff" }}>
          <thead>
            <tr>
              <th>ID</th>
              <th>Name</th>
              <th />
            </tr>
          </thead>
          {cates.map((cates: ICategory) =>
            <tbody key={cates.id_category}>
              <tr>
                <th scope="row">{cates.id_category}</th>
                <td>{cates.name_category}</td>
                <td>
                  <Button color="primary" onClick={() => handleEdit(cates)}>Edit</Button>{' '}
                  <Button color="danger" onClick={() => handleDelete(cates.id_category)}>Delete</Button>
                </td>
              </tr>
            </tbody>)}
        </Table>
        <PostCategory itemEdit={itemSelected} />
        <Link to="/"><Button color="warning">Return Home</Button></Link>
      </div>
    </>
  )
}
