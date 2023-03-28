from app.schemas.basic_info import BasicInfo

class Estabelecimento(BasicInfo):
    cnpj: str
    descricao: str
    email: str
    telefone: str