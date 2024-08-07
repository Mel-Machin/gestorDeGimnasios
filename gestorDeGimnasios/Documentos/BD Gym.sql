USE [master]
GO
/****** Object:  Database [Gym]    Script Date: 08/07/2024 16:51:43 ******/
CREATE DATABASE [Gym]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Gym', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Gym.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Gym_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Gym_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Gym] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Gym].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Gym] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Gym] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Gym] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Gym] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Gym] SET ARITHABORT OFF 
GO
ALTER DATABASE [Gym] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Gym] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Gym] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Gym] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Gym] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Gym] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Gym] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Gym] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Gym] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Gym] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Gym] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Gym] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Gym] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Gym] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Gym] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Gym] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Gym] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Gym] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Gym] SET  MULTI_USER 
GO
ALTER DATABASE [Gym] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Gym] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Gym] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Gym] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Gym] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Gym] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Gym] SET QUERY_STORE = ON
GO
ALTER DATABASE [Gym] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Gym]
GO
/****** Object:  User [ELBRUJOAQUINO\melal]    Script Date: 08/07/2024 16:51:43 ******/
CREATE USER [ELBRUJOAQUINO\melal] FOR LOGIN [ELBRUJOAQUINO\melal] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_CalcularVidaUtilRestante]    Script Date: 08/07/2024 16:51:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_CalcularVidaUtilRestante] (
    @id_Maquina INT
)
RETURNS INT
AS
BEGIN
    DECLARE @Fecha_compra DATE,
            @Vida_util INT,
            @VidaUtilRestante INT

    -- Obtener FechaCompra y VidaUtil de la tabla Maquinas
    SELECT @Fecha_compra = Fecha_compra, @Vida_util = Vida_util
    FROM Maquinas
    WHERE id_Maquina = @id_Maquina

    -- Calcular la vida útil restante
    SET @VidaUtilRestante = @Vida_util - DATEDIFF(YEAR, @Fecha_compra, GETDATE())

    RETURN @VidaUtilRestante
END
GO
/****** Object:  Table [dbo].[ejercicios]    Script Date: 08/07/2024 16:51:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ejercicios](
	[id_ejercicio] [numeric](5, 0) IDENTITY(1,1) NOT NULL,
	[Descripcion_ejercicio] [varchar](1000) NOT NULL,
	[Link_video_ejercicio] [nvarchar](2500) NULL,
	[Id_tipo_maquina] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_ejercicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[locales]    Script Date: 08/07/2024 16:51:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[locales](
	[id_local] [numeric](5, 0) IDENTITY(1,1) NOT NULL,
	[Nombre_local] [varchar](50) NOT NULL,
	[Ciudad_local] [varchar](50) NOT NULL,
	[Dirección_local] [varchar](100) NOT NULL,
	[Teléfono_local] [varchar](25) NOT NULL,
	[id_responsable] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_local] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[maquinas]    Script Date: 08/07/2024 16:51:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[maquinas](
	[id_maquina] [numeric](5, 0) IDENTITY(1,1) NOT NULL,
	[Id_tipo_maquina] [int] NULL,
	[Id_local] [numeric](5, 0) NULL,
	[Fecha_compra] [date] NULL,
	[Precio_compra] [money] NOT NULL,
	[Vida_util] [numeric](2, 0) NOT NULL,
	[Disponibilidad] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_maquina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Responsables]    Script Date: 08/07/2024 16:51:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Responsables](
	[id_responsable] [int] IDENTITY(1,1) NOT NULL,
	[nombre_responsable] [varchar](50) NOT NULL,
	[telefono_responsable] [varchar](15) NOT NULL,
	[usuario] [varchar](255) NOT NULL,
	[contrasenia] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_responsable] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rutinas]    Script Date: 08/07/2024 16:51:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rutinas](
	[id_rutina] [numeric](5, 0) IDENTITY(1,1) NOT NULL,
	[Descripcion_rutina] [varchar](250) NULL,
	[Tipo_rutina] [varchar](25) NOT NULL,
	[calificación_rutina_promedio] [decimal](2, 1) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_rutina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rutinas_ejercicios]    Script Date: 08/07/2024 16:51:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rutinas_ejercicios](
	[id_rutina] [numeric](5, 0) NOT NULL,
	[Id_ejercicio] [numeric](5, 0) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_rutina] ASC,
	[Id_ejercicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[socios]    Script Date: 08/07/2024 16:51:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[socios](
	[id_socio] [numeric](5, 0) IDENTITY(1,1) NOT NULL,
	[Tipo_socio] [varchar](50) NOT NULL,
	[Nombre_socio] [varchar](50) NOT NULL,
	[Apellido_socio] [varchar](50) NOT NULL,
	[Telefono_socio] [varchar](25) NOT NULL,
	[Mail_socio] [varchar](320) NULL,
	[Id_local] [numeric](5, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_socio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[socios_rutinas]    Script Date: 08/07/2024 16:51:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[socios_rutinas](
	[id_socio] [numeric](5, 0) NOT NULL,
	[Id_rutina] [numeric](5, 0) NOT NULL,
	[Fecha_inicio] [date] NOT NULL,
	[Fecha_fin] [date] NOT NULL,
	[Calificacion] [numeric](1, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_socio] ASC,
	[Id_rutina] ASC,
	[Fecha_inicio] ASC,
	[Fecha_fin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipos_maquinas]    Script Date: 08/07/2024 16:51:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipos_maquinas](
	[id_tipo_maquina] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_tipo_maquina] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_tipo_maquina] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ejercicios] ON 

INSERT [dbo].[ejercicios] ([id_ejercicio], [Descripcion_ejercicio], [Link_video_ejercicio], [Id_tipo_maquina]) VALUES (CAST(24 AS Numeric(5, 0)), N'Músculos implicados:  Principales: pectoral mayor (zona clavicular), tríceps y deltoides anterior. Secundarios: deltoides medio, coracobraquial, serrato anterior y subescapular. Antagonistas: dorsal mayor, bíceps y deltoides posterior.  Ejecución: Tumbado sobre un banco inclinado, no más de 30º ó 45º, se deben colocar los pies sobre el suelo y apoyar la espalda y la cabeza. Se sujeta la barra sobre la vertical de la frente, en pronación (palmas hacia los pies). Los antebrazos han de moverse perpendiculares al suelo, con un agarre algo más ancho que los hombros. Se inspira antes de sacar la barra del soporte, se desciende hasta rozar el pecho en su parte superior y se vuelve a subir verticalmente. Los codos permanecen separados del cuerpo. Se espira al terminar de subir.', NULL, 32)
INSERT [dbo].[ejercicios] ([id_ejercicio], [Descripcion_ejercicio], [Link_video_ejercicio], [Id_tipo_maquina]) VALUES (CAST(25 AS Numeric(5, 0)), N'Músculos implicados:  Principales: pectoral mayor y deltoides anterior. Secundarios: pectoral menor, coracobraquial, serrato anterior, subescapular y bíceps. Antagonistas: dorsal mayor, deltoides posterior y tríceps.  Ejecución: Hay que situarse de pie entre las dos poleas, con las piernas semiflexionadas (preferiblemente con una más adelantada), con el tronco ligeramente flexionado (entre 15º a 45º aproximadamente) y con la fijación de los músculos abdominales. Se parte de los brazos en cruz y los codos semiflexionados, se juntan cerrándose a modo de abrazo, al frente y abajo (casi en "aducción horizontal") sin variar la flexión del codo en todo el recorrido. Se inspira al abrir y se espira al terminar de cerrar.', NULL, 33)
INSERT [dbo].[ejercicios] ([id_ejercicio], [Descripcion_ejercicio], [Link_video_ejercicio], [Id_tipo_maquina]) VALUES (CAST(26 AS Numeric(5, 0)), N'Músculos implicados:  Principales: dorsal ancho, bíceps (corto), braquial y redondo mayor. Secundarios: pectoral mayor (inferior y externo), tríceps largo, redondo menor, romboides, braquiorradial, trapecio (inferior), bíceps (largo) y deltoides (clavicular y espinal). Antagonistas: pectoral mayor (clavicular) y tríceps.  Ejecución:Sujeto en suspensión en una barra horizontal, manos en pronación (nudillos hacia atrás) con una separación mayor a la de los hombros. Tiramos con los músculos dorsales acercando la zona superior del pecho a la barra al tiempo que arqueamos ligeramente el tronco hacia atrás. Las piernas permanecen relajadas o cruzadas detrás, con las rodillas flexionadas o no. Se inspira durante la primera mitad de la bajada y se espira al llegar arriba.', NULL, 34)
INSERT [dbo].[ejercicios] ([id_ejercicio], [Descripcion_ejercicio], [Link_video_ejercicio], [Id_tipo_maquina]) VALUES (CAST(27 AS Numeric(5, 0)), N'Músculos implicados: Principales: cuádriceps y glúteo mayor. Secundarios: isquiotibiales, aductores, gastrocnemios, lumbares, paravertebrales... Antagonistas: psoas, iliaco, sartorio...  Ejecución: De pie, con la mirada al frente, con los pies apuntando ligeramente hacia fuera (rotación lateral de la pierna 20º ó 30º) y algo más separados que las caderas, se sujeta la barra en pronación tras la cabeza sobre el trapecio y deltoides. Se baja flexionando las rodillas en dirección a los pies hasta que los muslos queden casi paralelos al suelo. El abdomen y el lumbar han de permanecer fuertemente contraídos. Los talones no se levantan, y se coloca, si es necesario, un pequeño taco bajo ellos (2 centímetros suelen bastar). Se inspira al comenzar a bajar, se bloquea en inspiración y se espira al terminar de subir; se debe ventilar bien y repetir.', NULL, 35)
INSERT [dbo].[ejercicios] ([id_ejercicio], [Descripcion_ejercicio], [Link_video_ejercicio], [Id_tipo_maquina]) VALUES (CAST(28 AS Numeric(5, 0)), N'Músculos implicados: Principales: cuádriceps, glúteo mayor y aductores. Secundarios: isquiotibiales... Antagonistas: psoas, iliaco, sartorio...  Ejecución: Recostado sobre el banco inclinado de la prensa, con total apoyo de la espalda y de la cadera, los pies sobre la plataforma con una separación ligeramente mayor que la cadera y las puntas un poco abiertas, se desciende hasta acercar los muslos al tronco pero sin elevar la cadera del respaldo. De forma controlada pero enérgica, se vuelve a levantar hasta casi la máxima extensión. Se inspira en el primer tercio de la bajada y se espira al terminar de subir.', NULL, 37)
INSERT [dbo].[ejercicios] ([id_ejercicio], [Descripcion_ejercicio], [Link_video_ejercicio], [Id_tipo_maquina]) VALUES (CAST(29 AS Numeric(5, 0)), N'Músculos implicados: Principales: cuádriceps (vasto interno, externo y crural). Secundarios: recto anterior del cuádriceps y deltoides glúteo (tensor de la fascia lata y fibras superficiales del glúteo mayor). Antagonistas: isquiotibiales, bíceps femoral corto, grácil, sartorio, gastrocnemios...  Ejecución: Nos colocamos sentados en el banco diseñado al efecto, con la parte superior de los tobillos bajo los topes acolchados. La parte posterior de la rodilla descansa en el borde del banco, en alineación con el eje de la máquina. Se levanta el peso, aproximadamente, desde los 90º hasta la extensión casi completa y se deja bajar en contracción excéntrica controlada. En cargas muy pesadas y en rehabilitación, se suele desaconsejar llevar la rodilla en gran flexión por la tensión que debe soportar. Se inspira al bajar y se espira al terminar de subir.', NULL, 36)
INSERT [dbo].[ejercicios] ([id_ejercicio], [Descripcion_ejercicio], [Link_video_ejercicio], [Id_tipo_maquina]) VALUES (CAST(30 AS Numeric(5, 0)), N'Músculos implicados: Principales: bíceps femoral corto, isquiotibiales (semimembranoso, semitendinoso y cabeza larga del bíceps femoral.) Secundarios: grácil, sartorio, gastrocnemios, poplíteo... Antagonistas: cuádriceps.  Ejecución: Nos colocamos en decúbito prono (sobre el pecho y el vientre) en un banco no totalmente plano (con ligera flexión en la cadera) y se sujetan con las manos los agarres o el propio banco para estabilizarse. Con los pies en flexión plantar, se colocan los rodillos casi en los talones y las rodillas fuera del banco en alineación con el eje de la máquina. Desde casi la máxima extensión, se sube en flexión de rodilla todo lo posible (unos 120º), de forma controlada. Nunca se debe bajar hasta la máxima extensión. Se inspira al comenzar a extender y se espira al terminar de flexionar.', NULL, 37)
INSERT [dbo].[ejercicios] ([id_ejercicio], [Descripcion_ejercicio], [Link_video_ejercicio], [Id_tipo_maquina]) VALUES (CAST(31 AS Numeric(5, 0)), N'Músculos implicados: Principales: bíceps braquial, braquial anterior y braquiorradial. Secundarios: pronador redondo, extensor largo radial del carpo, flexor superficial de los dedos, palmar largo... Antagonistas: tríceps y ancóneo  Ejecución: De pie, con las piernas un poco separadas para guardar el equilibrio, con el tronco, el hombro y las muñecas bloqueados, se sujeta la barra frente a los muslos en supinación (con las palmas hacia arriba) con un agarre de anchura ligeramente superior a los hombros. Se levanta de forma controlada hasta la flexión máxima (unos 145º, o menos si se tiene mucho volumen). Se inspira justo antes de subir y se espira al terminar de bajar.', NULL, 40)
INSERT [dbo].[ejercicios] ([id_ejercicio], [Descripcion_ejercicio], [Link_video_ejercicio], [Id_tipo_maquina]) VALUES (CAST(32 AS Numeric(5, 0)), N'Músculos implicados: Principales: deltoides (posterior) y trapecio. Secundarios: deltoides (medio), dorsal ancho, romboides, redondos, tríceps, infraespinoso y (lumbar y paravertebrales). Antagonistas: deltoides anterior, pectoral y bíceps.  Ejecución: De pie, con las piernas algo separadas y semiflexionadas, con el tronco bloqueado e inclinado hasta casi la horizontal, se sujetan las mancuernas en agarre neutro -con los codos hacia atrás- frente al cuerpo (colgando). Se elevan lateralmente y sin modificar la flexión de los codos hasta la altura del tronco. Los codos han de permanecer lo suficiente separados del tronco como para no implicar demasiado al dorsal. Se toma aire al comenzar a subir y se espira mientras se desciende sin soltarlo del todo.', NULL, 39)
SET IDENTITY_INSERT [dbo].[ejercicios] OFF
GO
SET IDENTITY_INSERT [dbo].[locales] ON 

INSERT [dbo].[locales] ([id_local], [Nombre_local], [Ciudad_local], [Dirección_local], [Teléfono_local], [id_responsable]) VALUES (CAST(13 AS Numeric(5, 0)), N'Fidias Gym', N'Colonia del sacramento', N'Intendente Suarez 145', N'+598 990388013', 41)
INSERT [dbo].[locales] ([id_local], [Nombre_local], [Ciudad_local], [Dirección_local], [Teléfono_local], [id_responsable]) VALUES (CAST(14 AS Numeric(5, 0)), N'Body empowered Gym', N'Colonia del sacramento', N'Gral. Flores 279', N'+598 91769986', 43)
INSERT [dbo].[locales] ([id_local], [Nombre_local], [Ciudad_local], [Dirección_local], [Teléfono_local], [id_responsable]) VALUES (CAST(15 AS Numeric(5, 0)), N'Gimnasio Black Sheep', N'Montevideo', N'Pernas 2474', N'+598 98368880', 46)
INSERT [dbo].[locales] ([id_local], [Nombre_local], [Ciudad_local], [Dirección_local], [Teléfono_local], [id_responsable]) VALUES (CAST(16 AS Numeric(5, 0)), N'YOU fitness area', N'Montevideo', N'Av. Luis Alverto de Herrera 1290', N'+598 95090787', 44)
INSERT [dbo].[locales] ([id_local], [Nombre_local], [Ciudad_local], [Dirección_local], [Teléfono_local], [id_responsable]) VALUES (CAST(17 AS Numeric(5, 0)), N'Revancha Box', N'Salto', N'Diego Lamas 40', N'+598 92191291', 40)
INSERT [dbo].[locales] ([id_local], [Nombre_local], [Ciudad_local], [Dirección_local], [Teléfono_local], [id_responsable]) VALUES (CAST(18 AS Numeric(5, 0)), N'Dojo Bushido', N'Durazno', N'18 de Julio 693', N'+598 99635844', 47)
INSERT [dbo].[locales] ([id_local], [Nombre_local], [Ciudad_local], [Dirección_local], [Teléfono_local], [id_responsable]) VALUES (CAST(19 AS Numeric(5, 0)), N'Motus', N'Punta del este', N'Pernambuco 2010', N'+598 98028161', 39)
INSERT [dbo].[locales] ([id_local], [Nombre_local], [Ciudad_local], [Dirección_local], [Teléfono_local], [id_responsable]) VALUES (CAST(20 AS Numeric(5, 0)), N'Gimnasio Guerreros Luis', N'Rocha', N'E. Yarza 569', N'+598 99768742', 42)
INSERT [dbo].[locales] ([id_local], [Nombre_local], [Ciudad_local], [Dirección_local], [Teléfono_local], [id_responsable]) VALUES (CAST(21 AS Numeric(5, 0)), N'FullGym', N'Dolores', N'Carlos Puig 1378', N'+598 99738414', 45)
SET IDENTITY_INSERT [dbo].[locales] OFF
GO
SET IDENTITY_INSERT [dbo].[maquinas] ON 

INSERT [dbo].[maquinas] ([id_maquina], [Id_tipo_maquina], [Id_local], [Fecha_compra], [Precio_compra], [Vida_util], [Disponibilidad]) VALUES (CAST(20 AS Numeric(5, 0)), 33, CAST(16 AS Numeric(5, 0)), CAST(N'2023-12-06' AS Date), 500.0000, CAST(10 AS Numeric(2, 0)), N'disponible')
INSERT [dbo].[maquinas] ([id_maquina], [Id_tipo_maquina], [Id_local], [Fecha_compra], [Precio_compra], [Vida_util], [Disponibilidad]) VALUES (CAST(21 AS Numeric(5, 0)), 33, CAST(16 AS Numeric(5, 0)), CAST(N'2021-12-28' AS Date), 3000.0000, CAST(7 AS Numeric(2, 0)), N'disponible')
INSERT [dbo].[maquinas] ([id_maquina], [Id_tipo_maquina], [Id_local], [Fecha_compra], [Precio_compra], [Vida_util], [Disponibilidad]) VALUES (CAST(22 AS Numeric(5, 0)), 37, CAST(17 AS Numeric(5, 0)), CAST(N'2020-06-01' AS Date), 1000.0000, CAST(8 AS Numeric(2, 0)), N'disponible')
INSERT [dbo].[maquinas] ([id_maquina], [Id_tipo_maquina], [Id_local], [Fecha_compra], [Precio_compra], [Vida_util], [Disponibilidad]) VALUES (CAST(23 AS Numeric(5, 0)), 39, CAST(19 AS Numeric(5, 0)), CAST(N'2018-10-08' AS Date), 2599.0000, CAST(10 AS Numeric(2, 0)), N'en reparacion')
INSERT [dbo].[maquinas] ([id_maquina], [Id_tipo_maquina], [Id_local], [Fecha_compra], [Precio_compra], [Vida_util], [Disponibilidad]) VALUES (CAST(24 AS Numeric(5, 0)), 39, CAST(19 AS Numeric(5, 0)), CAST(N'2023-07-20' AS Date), 1200.0000, CAST(5 AS Numeric(2, 0)), N'disponible')
INSERT [dbo].[maquinas] ([id_maquina], [Id_tipo_maquina], [Id_local], [Fecha_compra], [Precio_compra], [Vida_util], [Disponibilidad]) VALUES (CAST(25 AS Numeric(5, 0)), 40, CAST(18 AS Numeric(5, 0)), CAST(N'2024-01-17' AS Date), 100.0000, CAST(10 AS Numeric(2, 0)), N'disponible')
INSERT [dbo].[maquinas] ([id_maquina], [Id_tipo_maquina], [Id_local], [Fecha_compra], [Precio_compra], [Vida_util], [Disponibilidad]) VALUES (CAST(26 AS Numeric(5, 0)), 41, CAST(20 AS Numeric(5, 0)), CAST(N'2022-12-17' AS Date), 6000.0000, CAST(6 AS Numeric(2, 0)), N'disponible')
SET IDENTITY_INSERT [dbo].[maquinas] OFF
GO
SET IDENTITY_INSERT [dbo].[Responsables] ON 

INSERT [dbo].[Responsables] ([id_responsable], [nombre_responsable], [telefono_responsable], [usuario], [contrasenia]) VALUES (39, N'Alejandra Peña', N'096354789', N'Ale Peña', N'12345')
INSERT [dbo].[Responsables] ([id_responsable], [nombre_responsable], [telefono_responsable], [usuario], [contrasenia]) VALUES (40, N'Melanie Acosta', N'032125632', N'Mel ', N'Mel')
INSERT [dbo].[Responsables] ([id_responsable], [nombre_responsable], [telefono_responsable], [usuario], [contrasenia]) VALUES (41, N'Federico Otto', N'45227896', N'Fede Otto', N'Fede1234')
INSERT [dbo].[Responsables] ([id_responsable], [nombre_responsable], [telefono_responsable], [usuario], [contrasenia]) VALUES (42, N'Gladys Pereira', N'092165896', N'Pereira Gladys', N'1111')
INSERT [dbo].[Responsables] ([id_responsable], [nombre_responsable], [telefono_responsable], [usuario], [contrasenia]) VALUES (43, N'Gabriel Mansilla', N'099631235', N'GabrielM', N'5555')
INSERT [dbo].[Responsables] ([id_responsable], [nombre_responsable], [telefono_responsable], [usuario], [contrasenia]) VALUES (44, N'Anthony Ferreira', N'091235645', N'Thony ', N'12345')
INSERT [dbo].[Responsables] ([id_responsable], [nombre_responsable], [telefono_responsable], [usuario], [contrasenia]) VALUES (45, N'Alexis Vitalis', N'45226318', N'Vitalis', N'1999')
INSERT [dbo].[Responsables] ([id_responsable], [nombre_responsable], [telefono_responsable], [usuario], [contrasenia]) VALUES (46, N'Pedro', N'Cabrera', N'PCabrera', N'0000')
INSERT [dbo].[Responsables] ([id_responsable], [nombre_responsable], [telefono_responsable], [usuario], [contrasenia]) VALUES (47, N'Melanie', N'093213568', N'Melchu', N'1999')
INSERT [dbo].[Responsables] ([id_responsable], [nombre_responsable], [telefono_responsable], [usuario], [contrasenia]) VALUES (48, N'qqqqqq', N'099384772', N'wefrgbfdvsc', N'1234')
SET IDENTITY_INSERT [dbo].[Responsables] OFF
GO
SET IDENTITY_INSERT [dbo].[rutinas] ON 

INSERT [dbo].[rutinas] ([id_rutina], [Descripcion_rutina], [Tipo_rutina], [calificación_rutina_promedio]) VALUES (CAST(30 AS Numeric(5, 0)), N'Rutina de cuádriceps', N'competicion profesional', CAST(2.0 AS Decimal(2, 1)))
INSERT [dbo].[rutinas] ([id_rutina], [Descripcion_rutina], [Tipo_rutina], [calificación_rutina_promedio]) VALUES (CAST(31 AS Numeric(5, 0)), N'Rutina de trapecio', N'competicion amateur', NULL)
INSERT [dbo].[rutinas] ([id_rutina], [Descripcion_rutina], [Tipo_rutina], [calificación_rutina_promedio]) VALUES (CAST(32 AS Numeric(5, 0)), N'Rutina de bíceps', N'competicion profesional', NULL)
INSERT [dbo].[rutinas] ([id_rutina], [Descripcion_rutina], [Tipo_rutina], [calificación_rutina_promedio]) VALUES (CAST(33 AS Numeric(5, 0)), N'Rutina de femoral', N'salud', NULL)
INSERT [dbo].[rutinas] ([id_rutina], [Descripcion_rutina], [Tipo_rutina], [calificación_rutina_promedio]) VALUES (CAST(34 AS Numeric(5, 0)), N'Rutina de cuádriceps', N'competicion profesional', NULL)
INSERT [dbo].[rutinas] ([id_rutina], [Descripcion_rutina], [Tipo_rutina], [calificación_rutina_promedio]) VALUES (CAST(35 AS Numeric(5, 0)), N'Rutina de gemelos', N'competicion profesional', NULL)
INSERT [dbo].[rutinas] ([id_rutina], [Descripcion_rutina], [Tipo_rutina], [calificación_rutina_promedio]) VALUES (CAST(36 AS Numeric(5, 0)), N'Rutina de cardio', N'salud', NULL)
INSERT [dbo].[rutinas] ([id_rutina], [Descripcion_rutina], [Tipo_rutina], [calificación_rutina_promedio]) VALUES (CAST(37 AS Numeric(5, 0)), N'Rutina de hombro', N'competicion amateur', NULL)
INSERT [dbo].[rutinas] ([id_rutina], [Descripcion_rutina], [Tipo_rutina], [calificación_rutina_promedio]) VALUES (CAST(38 AS Numeric(5, 0)), N'Rutina de espalda', N'competicion profesional', NULL)
SET IDENTITY_INSERT [dbo].[rutinas] OFF
GO
INSERT [dbo].[rutinas_ejercicios] ([id_rutina], [Id_ejercicio]) VALUES (CAST(30 AS Numeric(5, 0)), CAST(26 AS Numeric(5, 0)))
INSERT [dbo].[rutinas_ejercicios] ([id_rutina], [Id_ejercicio]) VALUES (CAST(30 AS Numeric(5, 0)), CAST(28 AS Numeric(5, 0)))
INSERT [dbo].[rutinas_ejercicios] ([id_rutina], [Id_ejercicio]) VALUES (CAST(30 AS Numeric(5, 0)), CAST(29 AS Numeric(5, 0)))
INSERT [dbo].[rutinas_ejercicios] ([id_rutina], [Id_ejercicio]) VALUES (CAST(30 AS Numeric(5, 0)), CAST(30 AS Numeric(5, 0)))
GO
SET IDENTITY_INSERT [dbo].[socios] ON 

INSERT [dbo].[socios] ([id_socio], [Tipo_socio], [Nombre_socio], [Apellido_socio], [Telefono_socio], [Mail_socio], [Id_local]) VALUES (CAST(16 AS Numeric(5, 0)), N'premium', N'Pedro', N'López', N'1234567890', N'pedro@correo.com', CAST(17 AS Numeric(5, 0)))
INSERT [dbo].[socios] ([id_socio], [Tipo_socio], [Nombre_socio], [Apellido_socio], [Telefono_socio], [Mail_socio], [Id_local]) VALUES (CAST(17 AS Numeric(5, 0)), N'estandar', N'Ana', N'García', N'+598 987654321', N'ana@hotmail.com', CAST(17 AS Numeric(5, 0)))
INSERT [dbo].[socios] ([id_socio], [Tipo_socio], [Nombre_socio], [Apellido_socio], [Telefono_socio], [Mail_socio], [Id_local]) VALUES (CAST(18 AS Numeric(5, 0)), N'básico', N'José', N'Hernandez', N'+5491164765211', N'JH5211@gmail.com', CAST(19 AS Numeric(5, 0)))
INSERT [dbo].[socios] ([id_socio], [Tipo_socio], [Nombre_socio], [Apellido_socio], [Telefono_socio], [Mail_socio], [Id_local]) VALUES (CAST(19 AS Numeric(5, 0)), N'premium', N'Sofia', N'Espinoza', N'+598 92758421', N'sofiEspino5@hotmail.com', CAST(13 AS Numeric(5, 0)))
INSERT [dbo].[socios] ([id_socio], [Tipo_socio], [Nombre_socio], [Apellido_socio], [Telefono_socio], [Mail_socio], [Id_local]) VALUES (CAST(20 AS Numeric(5, 0)), N'premium', N'Selena', N'Venezuela', N'+59893445646', N'selena10@gmail.com', CAST(14 AS Numeric(5, 0)))
INSERT [dbo].[socios] ([id_socio], [Tipo_socio], [Nombre_socio], [Apellido_socio], [Telefono_socio], [Mail_socio], [Id_local]) VALUES (CAST(21 AS Numeric(5, 0)), N'básico', N'Matias', N'Castillo', N'+5491158476322', N'maticastillo@hotmail.com', CAST(16 AS Numeric(5, 0)))
INSERT [dbo].[socios] ([id_socio], [Tipo_socio], [Nombre_socio], [Apellido_socio], [Telefono_socio], [Mail_socio], [Id_local]) VALUES (CAST(22 AS Numeric(5, 0)), N'básico', N'Alexis', N'Tapia', N'+598 94567456', N'tapiaalexis@gmail.com', CAST(14 AS Numeric(5, 0)))
INSERT [dbo].[socios] ([id_socio], [Tipo_socio], [Nombre_socio], [Apellido_socio], [Telefono_socio], [Mail_socio], [Id_local]) VALUES (CAST(23 AS Numeric(5, 0)), N'premium', N'Gabriel', N'Reyes', N'+598 91456321', N'gabrielreyes23@hotmail.com', CAST(21 AS Numeric(5, 0)))
INSERT [dbo].[socios] ([id_socio], [Tipo_socio], [Nombre_socio], [Apellido_socio], [Telefono_socio], [Mail_socio], [Id_local]) VALUES (CAST(24 AS Numeric(5, 0)), N'premium', N'Benjamin', N'Gutiérrez', N'+598 96753357', N'benjigutierrez@gmail.com', CAST(18 AS Numeric(5, 0)))
INSERT [dbo].[socios] ([id_socio], [Tipo_socio], [Nombre_socio], [Apellido_socio], [Telefono_socio], [Mail_socio], [Id_local]) VALUES (CAST(25 AS Numeric(5, 0)), N'básico', N'Santiago', N'Castro', N'598 92788778', N'castrosanti@hotmail.com', CAST(17 AS Numeric(5, 0)))
SET IDENTITY_INSERT [dbo].[socios] OFF
GO
INSERT [dbo].[socios_rutinas] ([id_socio], [Id_rutina], [Fecha_inicio], [Fecha_fin], [Calificacion]) VALUES (CAST(16 AS Numeric(5, 0)), CAST(30 AS Numeric(5, 0)), CAST(N'2024-07-09' AS Date), CAST(N'2024-07-12' AS Date), CAST(2 AS Numeric(1, 0)))
INSERT [dbo].[socios_rutinas] ([id_socio], [Id_rutina], [Fecha_inicio], [Fecha_fin], [Calificacion]) VALUES (CAST(22 AS Numeric(5, 0)), CAST(32 AS Numeric(5, 0)), CAST(N'2024-04-01' AS Date), CAST(N'2024-05-01' AS Date), CAST(4 AS Numeric(1, 0)))
GO
SET IDENTITY_INSERT [dbo].[tipos_maquinas] ON 

INSERT [dbo].[tipos_maquinas] ([id_tipo_maquina], [Nombre_tipo_maquina]) VALUES (32, N'Banco inclinado para press')
INSERT [dbo].[tipos_maquinas] ([id_tipo_maquina], [Nombre_tipo_maquina]) VALUES (33, N'Poleas')
INSERT [dbo].[tipos_maquinas] ([id_tipo_maquina], [Nombre_tipo_maquina]) VALUES (34, N'pull-up bars')
INSERT [dbo].[tipos_maquinas] ([id_tipo_maquina], [Nombre_tipo_maquina]) VALUES (35, N'Barra olimpica')
INSERT [dbo].[tipos_maquinas] ([id_tipo_maquina], [Nombre_tipo_maquina]) VALUES (36, N'Prensa')
INSERT [dbo].[tipos_maquinas] ([id_tipo_maquina], [Nombre_tipo_maquina]) VALUES (37, N'Máquina de Extensión de piernas')
INSERT [dbo].[tipos_maquinas] ([id_tipo_maquina], [Nombre_tipo_maquina]) VALUES (38, N'Máquina de press de hombros')
INSERT [dbo].[tipos_maquinas] ([id_tipo_maquina], [Nombre_tipo_maquina]) VALUES (39, N'Máquina de triceps')
INSERT [dbo].[tipos_maquinas] ([id_tipo_maquina], [Nombre_tipo_maquina]) VALUES (40, N'Mancuernas')
INSERT [dbo].[tipos_maquinas] ([id_tipo_maquina], [Nombre_tipo_maquina]) VALUES (41, N'Cinta de correr')
SET IDENTITY_INSERT [dbo].[tipos_maquinas] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__locales__385720EF3243EE22]    Script Date: 08/07/2024 16:51:43 ******/
ALTER TABLE [dbo].[locales] ADD UNIQUE NONCLUSTERED 
(
	[Nombre_local] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [unico]    Script Date: 08/07/2024 16:51:43 ******/
ALTER TABLE [dbo].[Responsables] ADD  CONSTRAINT [unico] UNIQUE NONCLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[maquinas] ADD  DEFAULT (CONVERT([date],getdate())) FOR [Fecha_compra]
GO
ALTER TABLE [dbo].[socios_rutinas] ADD  DEFAULT (CONVERT([date],getdate())) FOR [Fecha_inicio]
GO
ALTER TABLE [dbo].[socios_rutinas] ADD  DEFAULT (dateadd(month,(1),CONVERT([date],getdate()))) FOR [Fecha_fin]
GO
ALTER TABLE [dbo].[ejercicios]  WITH CHECK ADD  CONSTRAINT [FK__ejercicio__Id_ti__4E88ABD4] FOREIGN KEY([Id_tipo_maquina])
REFERENCES [dbo].[tipos_maquinas] ([id_tipo_maquina])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[ejercicios] CHECK CONSTRAINT [FK__ejercicio__Id_ti__4E88ABD4]
GO
ALTER TABLE [dbo].[locales]  WITH CHECK ADD  CONSTRAINT [restriccion] FOREIGN KEY([id_responsable])
REFERENCES [dbo].[Responsables] ([id_responsable])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[locales] CHECK CONSTRAINT [restriccion]
GO
ALTER TABLE [dbo].[maquinas]  WITH CHECK ADD  CONSTRAINT [FK__maquinas__Id_loc__5070F446] FOREIGN KEY([Id_local])
REFERENCES [dbo].[locales] ([id_local])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[maquinas] CHECK CONSTRAINT [FK__maquinas__Id_loc__5070F446]
GO
ALTER TABLE [dbo].[maquinas]  WITH CHECK ADD FOREIGN KEY([Id_tipo_maquina])
REFERENCES [dbo].[tipos_maquinas] ([id_tipo_maquina])
GO
ALTER TABLE [dbo].[maquinas]  WITH CHECK ADD  CONSTRAINT [FK_maquinas_TablaPrincipal] FOREIGN KEY([Id_tipo_maquina])
REFERENCES [dbo].[tipos_maquinas] ([id_tipo_maquina])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[maquinas] CHECK CONSTRAINT [FK_maquinas_TablaPrincipal]
GO
ALTER TABLE [dbo].[rutinas_ejercicios]  WITH CHECK ADD  CONSTRAINT [FK__rutinas_e__Id_ej__52593CB8] FOREIGN KEY([Id_ejercicio])
REFERENCES [dbo].[ejercicios] ([id_ejercicio])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[rutinas_ejercicios] CHECK CONSTRAINT [FK__rutinas_e__Id_ej__52593CB8]
GO
ALTER TABLE [dbo].[rutinas_ejercicios]  WITH CHECK ADD  CONSTRAINT [FK__rutinas_e__id_ru__534D60F1] FOREIGN KEY([id_rutina])
REFERENCES [dbo].[rutinas] ([id_rutina])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[rutinas_ejercicios] CHECK CONSTRAINT [FK__rutinas_e__id_ru__534D60F1]
GO
ALTER TABLE [dbo].[socios]  WITH CHECK ADD  CONSTRAINT [FK__socios__Id_local__5441852A] FOREIGN KEY([Id_local])
REFERENCES [dbo].[locales] ([id_local])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[socios] CHECK CONSTRAINT [FK__socios__Id_local__5441852A]
GO
ALTER TABLE [dbo].[socios_rutinas]  WITH CHECK ADD FOREIGN KEY([Id_rutina])
REFERENCES [dbo].[rutinas] ([id_rutina])
GO
ALTER TABLE [dbo].[socios_rutinas]  WITH CHECK ADD  CONSTRAINT [FK__socios_ru__id_so__5629CD9C] FOREIGN KEY([id_socio])
REFERENCES [dbo].[socios] ([id_socio])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[socios_rutinas] CHECK CONSTRAINT [FK__socios_ru__id_so__5629CD9C]
GO
ALTER TABLE [dbo].[ejercicios]  WITH CHECK ADD CHECK  (([Link_video_ejercicio] like 'http://%' OR [Link_video_ejercicio] like 'https://%'))
GO
ALTER TABLE [dbo].[maquinas]  WITH CHECK ADD CHECK  (([disponibilidad]='no disponible' OR [disponibilidad]='en reparacion' OR [disponibilidad]='disponible'))
GO
ALTER TABLE [dbo].[rutinas]  WITH CHECK ADD CHECK  (([tipo_rutina]='competicion profesional' OR [tipo_rutina]='competicion amateur' OR [tipo_rutina]='salud'))
GO
ALTER TABLE [dbo].[socios]  WITH CHECK ADD CHECK  (([tipo_socio]='premium' OR [tipo_socio]='estandar' OR [tipo_socio]='básico'))
GO
ALTER TABLE [dbo].[socios_rutinas]  WITH CHECK ADD CHECK  (([calificacion]>=(1) AND [calificacion]<=(5)))
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerMaquinasOrdenadas]    Script Date: 08/07/2024 16:51:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerMaquinasOrdenadas]
    @Orden NVARCHAR(4)
AS
BEGIN
    IF @Orden = 'ASC'
    BEGIN
        SELECT * 
        FROM Maquinas 
        ORDER BY Fecha_compra ASC;
    END
    ELSE IF @Orden = 'DESC'
    BEGIN
        SELECT * 
        FROM Maquinas 
        ORDER BY Fecha_compra DESC;
    END
    ELSE
    BEGIN
        -- En caso de que el parámetro no sea ni 'ASC' ni 'DESC', devolver un error o un resultado por defecto
        SELECT 'El parámetro @Orden debe ser "ASC" o "DESC"' AS Mensaje;
    END
END;
GO
/****** Object:  Trigger [dbo].[ActualizarPromedioCalificaciones]    Script Date: 08/07/2024 16:51:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[ActualizarPromedioCalificaciones]
ON [dbo].[socios_rutinas]
AFTER INSERT, UPDATE
AS
BEGIN
DECLARE @promedios TABLE (id_rutina numeric (5),
promedio DECIMAL(3, 2));
INSERT INTO @promedios (id_rutina, promedio)
SELECT i.id_rutina, AVG (sr.Calificacion)
FROM inserted i
INNER JOIN socios_rutinas sr ON i.id_rutina = sr.id_rutina
GROUP BY i.id_rutina;
UPDATE rutinas
SET calificación_rutina_promedio = p.promedio
FROM rutinas r
INNER JOIN @promedios p ON r.id_rutina = p.id_rutina;
END;
GO
ALTER TABLE [dbo].[socios_rutinas] ENABLE TRIGGER [ActualizarPromedioCalificaciones]
GO
USE [master]
GO
ALTER DATABASE [Gym] SET  READ_WRITE 
GO
