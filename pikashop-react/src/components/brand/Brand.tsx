import React from "react";
import { Link } from "react-router-dom";
import axios from 'axios';
import IBrand from "../../interface/IBrand";
import { Table, Button } from 'reactstrap';
import PostBrand from "./PostBrand";
import Delete from "../../services/Delete";

export default function Brands(props: any) {

  const [cates, setCates] = React.useState([]);
  const [itemSelected, setSelected] = React.useState(null);

  const _fetchBrandData = () => {
    axios.get(`https://pikashop.azurewebsites.net/api/brands`)
      .then(res => {
        const cates = res.data;
        setCates(cates)
        console.log(cates);
      })
      .catch(error => console.log(error));
  }

  React.useEffect(() => {
    _fetchBrandData();
  }, [])

  const handleDelete = (itemId: any) => {
    Delete("brands", itemId)
      .then(res => {
        _fetchBrandData();
      }).catch(err => {
        console.log(err);
      })
  }

  const handleEdit = (itemEdit: any) => {
    setSelected(itemEdit);
  }

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
        {cates.map((cates: IBrand) =>
          <tbody key={cates.Id}>
            <tr>
              <th scope="row">{cates.Id}</th>
              <td>{cates.Name}</td>
              <td>
                <Button color="primary" onClick={() => handleEdit(cates)}>Edit</Button>
                <Button color="danger" onClick={() => handleDelete(cates.Id)} >Delete</Button>
              </td>
            </tr>
          </tbody>)}
      </Table>
      <PostBrand itemEdit={itemSelected} />
      <Button color="warning"><Link to="/">Return Home</Link></Button>
    </>

  )
}
