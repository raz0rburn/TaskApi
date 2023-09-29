--
-- PostgreSQL database dump
--

-- Dumped from database version 14.9
-- Dumped by pg_dump version 14.9

-- Started on 2023-09-30 01:19:37

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 209 (class 1259 OID 16395)
-- Name: TaskItems; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."TaskItems" (
    "Id" integer NOT NULL,
    "Name" character(128),
    "DueDate" character(10),
    "CreationDate" character(10),
    "CompletionDate" character(10),
    "Description" character(1024),
    "Status" integer,
    "IsDeleted" integer
);


ALTER TABLE public."TaskItems" OWNER TO postgres;

--
-- TOC entry 210 (class 1259 OID 16400)
-- Name: TaskItem_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."TaskItem_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."TaskItem_Id_seq" OWNER TO postgres;

--
-- TOC entry 3312 (class 0 OID 0)
-- Dependencies: 210
-- Name: TaskItem_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."TaskItem_Id_seq" OWNED BY public."TaskItems"."Id";


--
-- TOC entry 3163 (class 2604 OID 16401)
-- Name: TaskItems Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TaskItems" ALTER COLUMN "Id" SET DEFAULT nextval('public."TaskItem_Id_seq"'::regclass);


--
-- TOC entry 3305 (class 0 OID 16395)
-- Dependencies: 209
-- Data for Name: TaskItems; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."TaskItems" ("Id", "Name", "DueDate", "CreationDate", "CompletionDate", "Description", "Status", "IsDeleted") FROM stdin;
3	work                                                                                                                            	\N	\N	\N	\N	0	1
7	dancing                                                                                                                         	2023-09-29	2023-09-29	\N	\N	0	1
5	Eat                                                                                                                             	2023-09-29	2023-09-29	\N	\N	0	0
6	eat                                                                                                                             	2023-09-30	2023-09-29	\N	\N	0	0
8	eat                                                                                                                             	2023-10-2 	2023-09-29	\N	\N	0	0
9	eat                                                                                                                             	2023-09-30	2023-09-29	\N	\N	0	0
1	play a new                                                                                                                      	\N	\N	\N	\N	0	0
0	Eat                                                                                                                             	\N	\N	\N	\N	0	0
\.


--
-- TOC entry 3313 (class 0 OID 0)
-- Dependencies: 210
-- Name: TaskItem_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."TaskItem_Id_seq"', 10, true);


--
-- TOC entry 3165 (class 2606 OID 16403)
-- Name: TaskItems TaskItems_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TaskItems"
    ADD CONSTRAINT "TaskItems_pkey" PRIMARY KEY ("Id");


-- Completed on 2023-09-30 01:19:38

--
-- PostgreSQL database dump complete
--

