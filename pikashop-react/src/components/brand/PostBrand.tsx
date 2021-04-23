import React, { useState } from "react";
import axios from 'axios';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { useSelector } from "react-redux";
import { selectUser } from "../../store/auth-slice";
import Edit from "../../services/Edit";

export default ({ itemEdit }: any) => {
    const [nameBrand, setName] = useState('');

    const user = useSelector(selectUser);

    React.useEffect(() => {
        console.log(itemEdit)
        if (itemEdit != null)
            setName(itemEdit.Name);
    }, [itemEdit])

    const handleChange = (event: any) => {
        setName(event.target.value);
    }

    const handleSubmit = (event: any) => {
        event.preventDefault();
        if (itemEdit == null) {
            axios.post(
                `https://pikashop.azurewebsites.net/api/brands`,
                { name: nameBrand },
                {
                    headers: { "Authorization": `Bearer ${user?.token}` },
                }).then(res => {
                    console.log(res.data);
                }).catch(err => {
                    console.log(err);
                })
        }
        else {

            Edit("brands", itemEdit.Id, { name: nameBrand })
                .then(res => {
                    console.log({ name: nameBrand });
                }).catch(err => {
                    console.log(err);
                })
        }
    }


    return (
        <>
            <br />
            <h5>Add new brand</h5>
            <Form inline onSubmit={handleSubmit}>
                <FormGroup className="mb-2 mr-sm-2 mb-sm-0">
                    <Label for="exampleEmail" className="mr-sm-2">Name</Label>
                    <Input type="text" name="name_brand" value={nameBrand} placeholder="New brand..." onChange={handleChange} />
                </FormGroup>
                <Button type="submit">{itemEdit ? "Save" : "Add"}</Button>
            </Form>
            <hr />
        </>
    )
}

