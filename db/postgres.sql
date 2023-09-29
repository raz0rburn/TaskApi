--
-- PostgreSQL database dump
--

-- Dumped from database version 14.9
-- Dumped by pg_dump version 14.9

-- Started on 2023-09-29 13:53:02

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
    "Status" character(16),
    "DueDate" character(10),
    "CreationDate" character(10),
    "CompletionDate" character(10),
    "Description" character(1024)
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
-- TOC entry 3313 (class 0 OID 0)
-- Dependencies: 210
-- Name: TaskItem_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."TaskItem_Id_seq" OWNED BY public."TaskItems"."Id";


--
-- TOC entry 3164 (class 2604 OID 16401)
-- Name: TaskItems Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TaskItems" ALTER COLUMN "Id" SET DEFAULT nextval('public."TaskItem_Id_seq"'::regclass);


--
-- TOC entry 3306 (class 0 OID 16395)
-- Dependencies: 209
-- Data for Name: TaskItems; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."TaskItems" ("Id", "Name", "Status", "DueDate", "CreationDate", "CompletionDate", "Description") FROM stdin;
0	Eat                                                                                                                             	\N	\N	\N	\N	\N
1	play a new                                                                                                                      	\N	\N	\N	\N	\N
2	walk                                                                                                                            	\N	\N	\N	\N	\N
3	work                                                                                                                            	\N	\N	\N	\N	\N
4	relax                                                                                                                           	\N	\N	\N	\N	\N
5	driving                                                                                                                         	Created         	\N	\N	\N	\N
6	swimming                                                                                                                        	Created         	\N	\N	\N	\N
7	dancing                                                                                                                         	Created         	2023-09-29	2023-09-29	\N	\N
8	dancing                                                                                                                         	Completed       	2023-09-28	2023-09-28	2023-09-28	\N
\.


--
-- TOC entry 3314 (class 0 OID 0)
-- Dependencies: 210
-- Name: TaskItem_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."TaskItem_Id_seq"', 4, true);


--
-- TOC entry 3166 (class 2606 OID 16403)
-- Name: TaskItems TaskItems_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TaskItems"
    ADD CONSTRAINT "TaskItems_pkey" PRIMARY KEY ("Id");


-- Completed on 2023-09-29 13:53:02

--
-- PostgreSQL database dump complete
--

