import React from "react";
import { Link } from "react-router-dom";
import ICategory from "../../interface/ICategory";
import { Table, Button } from 'reactstrap';
import PostCategory from "./PostCategory";
import Delete from "../../services/Delete"
import GetList from "../../services/GetList";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

export default function Category(props: any) {

  const [cates, setCates] = React.useState([]);
  const [itemSelected, setSelected] = React.useState(null);

  const _fetchCategoryData = () => {
    GetList("category")
      .then(res => {
        const cates = res.data;
        setCates(cates)
        console.log(cates);
      }).catch(err => {
        console.log(err);
      })
  }

  React.useEffect(() => {
    _fetchCategoryData();
  }, [])

  const handleDelete = (itemId: any) => {
    Delete("category", itemId)
      .then(res => {
        _fetchCategoryData();
        toast.success(`Delete a category has Id is ${itemId} Success notification`, { position: toast.POSITION.TOP_RIGHT, autoClose: 3000 });
      }).catch(err => {
        console.log(err);
        toast.error("Error notification", { position: toast.POSITION.TOP_RIGHT, autoClose: 3000 });
      })
  }

  const handleChange = () => {
    _fetchCategoryData();
  }

  const handleEdit = (itemEdit: any) => {
    setSelected(itemEdit);
  }

  return (
    <>
      <div className="container" style={{ backgroundColor: "#ffffff", borderRadius: 10, padding: 30, height: 650, color: "#000000" }}>
        <h3 style={{ color: "#000000" }}>List Categories</h3>
        <Table style={{ color: "#000000" }}>
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
                  <ToastContainer />
                </td>
              </tr>
            </tbody>)}
        </Table>
        <PostCategory itemEdit={itemSelected} onChange={handleChange} />
        <Link to="/"><Button color="warning" style={{ color: "#ffffff" }}>Return Home</Button></Link>
      </div>
    </>
  )
}
