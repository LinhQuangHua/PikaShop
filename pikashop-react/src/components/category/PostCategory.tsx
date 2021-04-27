import React, { useState } from "react";
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import Edit from "../../services/Edit";
import Create from "../../services/Create";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

export default ({ itemEdit, onChange }: any) => {

    const [nameCate, setName] = useState('');

    React.useEffect(() => {
        console.log(itemEdit)
        if (itemEdit != null)
            setName(itemEdit.name_category);
    }, [itemEdit])

    const handleChange = (event: any) => {
        setName(event.target.value);
    }

    const handleSubmit = (event: any) => {
        event.preventDefault();
        if (itemEdit == null) {
            Create("category", { name_category: nameCate })
                .then(res => {
                    console.log({ name_category: nameCate });
                    onChange();
                    toast.success(`Add a new category ${nameCate} Success notification`, { position: toast.POSITION.TOP_RIGHT, autoClose: 3000 });
                }).catch(err => {
                    console.log(err);
                    toast.error("Error notification", { position: toast.POSITION.TOP_RIGHT, autoClose: 3000 });
                })
        }
        else {

            Edit("category", itemEdit.id_category, { name_category: nameCate })
                .then(res => {
                    console.log({ name_category: nameCate });
                    onChange();
                    toast.success(`Edit a category has Id is ${itemEdit.id_category} Success notification`, { position: toast.POSITION.TOP_RIGHT, autoClose: 3000 });
                }).catch(err => {
                    console.log(err);
                    toast.error("Error notification", { position: toast.POSITION.TOP_RIGHT, autoClose: 3000 });
                })
        }
    }

    return (
        <>
            <br />
            <h5>Add new category</h5>
            <Form inline onSubmit={handleSubmit}>
                <FormGroup className="mb-2 mr-sm-2 mb-sm-0">
                    <Label for="exampleEmail" className="mr-sm-2">Name</Label>
                    <Input type="text" value={nameCate} placeholder="New category..." onChange={handleChange} />
                </FormGroup>
                <Button type="submit">{itemEdit ? "Save" : "Add"}</Button>
                <ToastContainer />
            </Form>
            <hr />
        </>
    )
}

