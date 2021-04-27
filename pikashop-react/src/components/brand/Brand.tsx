import React from "react";
import { Link } from "react-router-dom";
import IBrand from "../../interface/IBrand";
import { Table, Button } from 'reactstrap';
import PostBrand from "./PostBrand";
import Delete from "../../services/Delete";
import GetList from "../../services/GetList";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

export default function Brands(props: any) {

  const [cates, setCates] = React.useState([]);
  const [itemSelected, setSelected] = React.useState(null);

  const _fetchBrandData = () => {
    GetList("brands")
      .then(res => {
        const cates = res.data;
        setCates(cates)
        console.log(cates);
      }).catch(err => {
        console.log(err);
      })
  }

  React.useEffect(() => {
    _fetchBrandData();
  }, [])

  const handleDelete = (itemId: any) => {
    Delete("brands", itemId)
      .then(res => {
        _fetchBrandData();
        toast.success(`Delete category has Id ${itemId} Success notification`, { position: toast.POSITION.TOP_RIGHT });
      }).catch(err => {
        console.log(err);
        toast.error("Error notification", { position: toast.POSITION.TOP_RIGHT });
      })
  }

  const handleChange = () => {
    _fetchBrandData();
  }

  const handleEdit = (itemEdit: any) => {
    setSelected(itemEdit);
  }

  return (
    <>
      <div className="container" style={{ backgroundColor: "#6600ff", borderRadius: 10, padding: 30, height: 650, color: "#ffffff" }}>
        <h3>List Brands</h3>
        <Table style={{ color: "#ffffff" }}>
          <thead>
            <tr>
              <th>ID</th>
              <th>Name</th>
              <th />
            </tr>
          </thead>
          {cates.map((cates: IBrand) =>
            <tbody key={cates.Id}>
              <tr>
                <th scope="row">{cates.Id}</th>
                <td>{cates.Name}</td>
                <td>
                  <Button color="primary" onClick={() => handleEdit(cates)}>Edit</Button>{' '}
                  <Button color="danger" onClick={() => handleDelete(cates.Id)} >Delete</Button>
                  <ToastContainer />
                </td>
              </tr>
            </tbody>)}
        </Table>
        <PostBrand itemEdit={itemSelected} onChange={handleChange} />
        <Link to="/"><Button color="warning">Return Home</Button></Link>
      </div>
    </>
  )
}
