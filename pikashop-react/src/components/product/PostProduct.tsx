import React, { useState } from "react";
import { Col, Button, Form, FormGroup, Label, Input } from 'reactstrap';
import Edit from "../../services/Edit";
import Create from "../../services/Create";

export default ({ itemEdit, onChange }: any) => {
    const [namePro, setName] = useState(
        { name_product: '', image: '', ThumbnailImage: '', price: null, height: null, weight: null, description: '', quantity: null, id_brand: 1, id_category: 1 } as any
    );

    React.useEffect(() => {
        if (itemEdit != null) setName(itemEdit)
        console.log(itemEdit);
    }, [itemEdit])

    const handleChange = (event: any) => {
        const { name, value } = event.target

        if (name === "ThumbnailImage") {

            setName({ ...namePro, ThumbnailImage: event.target.files[0], image: event.target.files[0] })
        }
        else {
            setName({
                ...namePro,
                [name]: value
            })
        }

    }

    const handleSubmit = (event: any) => {
        event.preventDefault();
        var postData = new FormData();

        Object.keys(namePro).forEach(function (key) {
            postData.append(key, namePro[key]);
        });
        if (itemEdit == null) {
            Create("product", postData)
                .then(res => {
                    console.log(postData);
                    onChange();
                }).catch(err => {
                    console.log(err);
                })
        }
        else {
            Edit("product", itemEdit.id_product, postData)
                .then(res => {
                    console.log({ ...postData });
                    onChange();
                }).catch(err => {
                    console.log(err);
                })
        }

    }
    return (
        <>
            <br />
            <h5 style={{ color: "#ffffff" }}>Add new brand</h5>
            <Form inline onSubmit={handleSubmit} style={{ color: "#ffffff" }}>
                <FormGroup>
                    <Col>
                        <Label sm={3}>Name</Label>
                        <Input type="text" value={namePro.name_product} name="name_product" placeholder="Name product..." onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Col>
                        <Label sm={3}>Price</Label>
                        <Input type="number" value={namePro.price} name="price" placeholder="Price product..." onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Col>
                        <Label sm={3}>Height</Label>
                        <Input type="number" value={namePro.height} name="height" placeholder="Height product..." onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Col>
                        <Label sm={3}>Weight</Label>
                        <Input type="number" value={namePro.weight} name="weight" placeholder="Weight product..." onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Col>
                        <Label sm={4}>Quantity</Label>
                        <Input type="number" value={namePro.quantity} name="quantity" placeholder="Quantity product..." onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Col sm={10}>
                        <Label sm={3}>Brand</Label>
                        <Input type="number" value={namePro.id_brand} name="id_brand" placeholder="Brand product..." onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Col>
                        <Label sm={4}>Category</Label>
                        <Input type="number" value={namePro.id_category} name="id_category" placeholder="Category product..." onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Col sm={10}>
                        <Label sm={3}>Description</Label>
                        <Input type="textarea" value={namePro.description} rows="4" cols="50" name="description" placeholder="Description product..." onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Col>
                        <Label>Image</Label>
                        <Input type="file" name="ThumbnailImage" onChange={handleChange} />
                    </Col>
                </FormGroup>
                <FormGroup>
                    <Col>
                        <Button type="submit" color="success" style={{ width: 100 }}>{itemEdit ? "Save" : "Add"}</Button>
                    </Col>
                </FormGroup>
            </Form>
            <hr />
        </>
    )
}