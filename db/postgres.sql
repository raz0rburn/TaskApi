--
-- PostgreSQL database dump
--

-- Dumped from database version 14.9
-- Dumped by pg_dump version 14.9

-- Started on 2023-10-12 22:44:45

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
    "Id" bigint NOT NULL,
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
-- TOC entry 3325 (class 0 OID 0)
-- Dependencies: 210
-- Name: TaskItem_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."TaskItem_Id_seq" OWNED BY public."TaskItems"."Id";


--
-- TOC entry 212 (class 1259 OID 32800)
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    "Id" bigint NOT NULL,
    "FirstName" character(32) NOT NULL,
    "LastName" character(32) NOT NULL,
    "Patronymic" character(32) NOT NULL,
    "Username" character(32) NOT NULL,
    "Email" character(32) NOT NULL,
    "Password" character(32) NOT NULL
);


ALTER TABLE public."Users" OWNER TO postgres;

--
-- TOC entry 211 (class 1259 OID 32799)
-- Name: Users_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Users_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Users_Id_seq" OWNER TO postgres;

--
-- TOC entry 3326 (class 0 OID 0)
-- Dependencies: 211
-- Name: Users_Id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Users_Id_seq" OWNED BY public."Users"."Id";


--
-- TOC entry 3169 (class 2604 OID 32782)
-- Name: TaskItems Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TaskItems" ALTER COLUMN "Id" SET DEFAULT nextval('public."TaskItem_Id_seq"'::regclass);


--
-- TOC entry 3170 (class 2604 OID 32803)
-- Name: Users Id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users" ALTER COLUMN "Id" SET DEFAULT nextval('public."Users_Id_seq"'::regclass);


--
-- TOC entry 3316 (class 0 OID 16395)
-- Dependencies: 209
-- Data for Name: TaskItems; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."TaskItems" ("Id", "Name", "DueDate", "CreationDate", "CompletionDate", "Description", "Status", "IsDeleted") FROM stdin;
3	work                                                                                                                            	\N	\N	\N	\N	0	1
7	dancing                                                                                                                         	2023-09-29	2023-09-29	\N	\N	0	1
5	Eat                                                                                                                             	2023-09-29	2023-09-29	\N	\N	0	0
6	eat                                                                                                                             	2023-09-30	2023-09-29	\N	\N	0	0
8	eat                                                                                                                             	2023-10-2 	2023-09-29	\N	\N	0	0
12	walk                                                                                                                            	2023-10-1 	2023-10-1 	\N	\N	0	0
17	play                                                                                                                            	2023-10-1 	2023-10-1 	\N	play the guitar                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 	0	0
15	play                                                                                                                            	2023-10-2 	2023-10-1 	\N	play the new guitar                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             	0	0
0	Eat                                                                                                                             	2023-10-3 	2023-10-1 	2023-10-01	eat food in the restoraunt                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      	2	0
16	play                                                                                                                            	2023-10-2 	2023-10-1 	          	play the electroguitar                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          	0	0
18	play                                                                                                                            	2023-10-1 	2023-10-1 	2023-10-01	play the guitar                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 	2	0
19	swim                                                                                                                            	2023-10-1 	2023-10-1 	\N	in a pool                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       	2	0
20	swim                                                                                                                            	2023-10-1 	2023-10-1 	2023-10-01	in a pool                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       	2	0
21	swim                                                                                                                            	2023-10-2 	2023-10-2 	2023-10-02	in a pool                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       	2	0
\.


--
-- TOC entry 3319 (class 0 OID 32800)
-- Dependencies: 212
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Users" ("Id", "FirstName", "LastName", "Patronymic", "Username", "Email", "Password") FROM stdin;
3	user1                           	user1                           	user1                           	user1                           	sdf@sdfs.ru                     	123                             
1	kirill                          	string                          	string                          	kirill                          	kirill@ssdf.ru                  	123                             
20	1                               	test                            	test                            	1                               	1@sdf.ru                        	1                               
22	1                               	test                            	test                            	2                               	2@sdf.ru                        	1                               
23	admin                           	admin                           	test                            	admin                           	3@sdf.ru                        	admin                           
\.


--
-- TOC entry 3327 (class 0 OID 0)
-- Dependencies: 210
-- Name: TaskItem_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."TaskItem_Id_seq"', 21, true);


--
-- TOC entry 3328 (class 0 OID 0)
-- Dependencies: 211
-- Name: Users_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Users_Id_seq"', 23, true);


--
-- TOC entry 3172 (class 2606 OID 32784)
-- Name: TaskItems TaskItems_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."TaskItems"
    ADD CONSTRAINT "TaskItems_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 3174 (class 2606 OID 32807)
-- Name: Users Users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 3176 (class 2606 OID 32869)
-- Name: Users Users_ukey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_ukey" UNIQUE ("Username") INCLUDE ("Email");


-- Completed on 2023-10-12 22:44:45

--
-- PostgreSQL database dump complete
--

