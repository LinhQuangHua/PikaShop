import React from "react";
import { Link } from "react-router-dom";
import axios from 'axios';
import IProduct from "../../interface/IProduct";
import { Table, Button } from 'reactstrap';
import PostProduct from './PostProduct';
import Delete from "../../services/Delete";
import { hostURL } from "../../config";

export default function Product(props: any) {

  const [cates, setCates] = React.useState([]);
  const [itemSelected, setSelected] = React.useState(null);

  const _fetchProductData = () => {
    axios.get(hostURL + `/api/product`)
      .then(res => {
        const cates = res.data;
        setCates(cates);
        console.log(cates);
      })
      .catch(error => console.log(error));
  }

  React.useEffect(() => {
    _fetchProductData();
  }, [])

  const handleDelete = (itemId: any) => {
    Delete("product", itemId)
      .then(res => {
        _fetchProductData();
      }).catch(err => {
        console.log(err);
      })
  }

  const handleEdit = (itemEdit: any) => {
    setSelected(itemEdit);
  }

  return (
    <>
      <div className="container" style={{ backgroundColor: "#6600ff", borderRadius: 10, padding: 30, height: "auto" }}>
        <h3>List Products</h3>
        <Table style={{ color: "#ffffff" }}>
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
              <th />
            </tr>
          </thead>
          {cates.map((cates: IProduct) =>
            <tbody key={cates.id_product}>
              <tr>
                <th scope="row">{cates.id_product}</th>
                <td>{cates.name_product}</td>
                <td><img src={hostURL + "/" + cates.ThumbnailImageUrl} style={{ width: 100, height: 100 }} alt="Product_image"></img></td>
                <td>{cates.price}</td>
                <td>{cates.height}</td>
                <td>{cates.weight}</td>
                <td>{cates.quantity}</td>
                <td>{cates.description}</td>
                <td>{cates.name_brand}</td>
                <td>{cates.name_category}</td>
                <td>
                  <Button color="primary" style={{ marginBottom: 10 }} onClick={() => handleEdit(cates)}>Edit</Button>
                  <Button color="danger" onClick={() => handleDelete(cates.id_product)}>Delete</Button>
                </td>
              </tr>
            </tbody>)}
        </Table>
        <PostProduct itemEdit={itemSelected} />
        <Link to="/"><Button color="warning">Return Home</Button></Link>
      </div>
    </>

  )
}

