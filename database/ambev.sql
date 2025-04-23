-- BRANCH

CREATE TABLE public.branch (
    name character varying(100) NOT NULL,
    id uuid DEFAULT gen_random_uuid() NOT NULL
);

ALTER TABLE ONLY public.branch ADD CONSTRAINT branch_pkey PRIMARY KEY (id);

-- END BRANCH

-- PRODUCT

CREATE TABLE public.product (
    name character varying(100) NOT NULL,
    id uuid DEFAULT gen_random_uuid() NOT NULL
);

ALTER TABLE ONLY public.product ADD CONSTRAINT product_pkey PRIMARY KEY (id);

-- END PRODUCT

-- CUSTOMER

CREATE TABLE public.customer (
    name character varying(100) NOT NULL,
    id uuid DEFAULT gen_random_uuid() NOT NULL
);

ALTER TABLE ONLY public.customer ADD CONSTRAINT customer_pkey PRIMARY KEY (id);

-- END CUSTOMER

-- ORDER 

CREATE TABLE public.order (
    saleDate timestamp with time zone NOT NULL,
    isCancelled boolean DEFAULT false NOT NULL,
    id uuid DEFAULT gen_random_uuid() NOT NULL,
    idCustomer uuid NOT NULL,
    idBranch uuid NOT NULL,
    saleNumber uuid DEFAULT gen_random_uuid() NOT NULL
);

ALTER TABLE ONLY public.order ADD CONSTRAINT order_pkey PRIMARY KEY (id);

CREATE INDEX fki_branch_fk ON public.order USING btree (idBranch);

CREATE INDEX fki_customer_fk ON public.order USING btree (idCustomer);

ALTER TABLE ONLY public.order ADD CONSTRAINT branch_fk FOREIGN KEY (idBranch) REFERENCES public.branch(id) NOT VALID;

ALTER TABLE ONLY public.order ADD CONSTRAINT customer_fk FOREIGN KEY (idCustomer) REFERENCES public.customer(id) NOT VALID;

-- END ORDER

-- ORDER ITEM

CREATE TABLE public.orderItem (
    quantity integer NOT NULL,
    unitPrice numeric(6,2) NOT NULL,
    discount numeric(6,2),
    idOrder uuid NOT NULL,
    idProduct uuid NOT NULL,
    id uuid DEFAULT gen_random_uuid() NOT NULL
);

ALTER TABLE ONLY public.orderItem ADD CONSTRAINT orderItem_pkey PRIMARY KEY (id);

CREATE INDEX fki_order_fk ON public.orderItem USING btree (idOrder);

CREATE INDEX fki_product_fk ON public.orderItem USING btree (idProduct);

ALTER TABLE ONLY public.orderItem ADD CONSTRAINT order_fk FOREIGN KEY (idOrder) REFERENCES public.order(id) NOT VALID;

ALTER TABLE ONLY public.orderItem ADD CONSTRAINT product_fk FOREIGN KEY (idProduct) REFERENCES public.product(id) NOT VALID;

-- END ORDER ITEM

INSERT INTO public.branch (name, id) VALUES ('Brazil', '49517f1e-3623-439a-ba2e-d30e73137a00');

INSERT INTO public.customer (name, id) VALUES ('John Sales', '6b662172-20fe-4aa8-aa3f-de59f5a1225d');

INSERT INTO public.product (name, id) VALUES ('iPhone 16 256GB Black', '13f16715-b932-483c-a4a7-602dea6fe787');
INSERT INTO public.product (name, id) VALUES ('Samsung Galaxy S25 512GB', 'b73b97b8-71be-4fac-a2f8-7cd99abac35a');
