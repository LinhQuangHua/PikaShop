import React from "react";
import { Link } from "react-router-dom";
import IUser from "../../interface/IUser";
import { Table, Button } from 'reactstrap';
import GetList from "../../services/GetList";

export default function Brands(props: any) {

  const [cates, setCates] = React.useState([]);

  const _fetchUserData = () => {
    GetList("user")
      .then(res => {
        const cates = res.data;
        setCates(cates)
        console.log(cates);
      }).catch(err => {
        console.log(err);
      })
  }

  React.useEffect(() => {
    _fetchUserData();
  }, [])

  return (
    <>
      <div className="container" style={{ backgroundColor: "#000000b3", borderRadius: 10, padding: 30, height: 650 }}>
        <h3>List Users</h3>
        <Table style={{ color: "#ffffff" }}>
          <thead>
            <tr>
              <th>ID User</th>
              <th>Email</th>
              <th>Phone Number</th>
            </tr>
          </thead>
          {cates.map((cates: IUser) =>
            <tbody key={cates.id_user}>
              <tr>
                <th scope="row">{cates.id_user}</th>
                <td>{cates.mail_user}</td>
                <td>{cates.phone}</td>
              </tr>
            </tbody>)}
        </Table>
        <Link to="/"><Button color="warning" style={{ color: "#ffffff" }}>Return Home</Button></Link>
      </div>
    </>
  )
}
