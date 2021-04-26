import React, { useState } from "react";
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import Edit from "../../services/Edit";
import Create from "../../services/Create";

export default ({ itemEdit }: any) => {

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
                }).catch(err => {
                    console.log(err);
                })
        }
        else {

            Edit("category", itemEdit.id_category, { name_category: nameCate })
                .then(res => {
                    console.log({ name_category: nameCate });
                }).catch(err => {
                    console.log(err);
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
            </Form>
            <hr />
        </>
    )
}

