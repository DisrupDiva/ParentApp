from typing import Union

from fastapi import FastAPI
from starlette.responses import JSONResponse

from app.schemas.estabelecimento import Estabelecimento
from app.schemas.servico import Servico

app = FastAPI()


# uvicorn main:app --reload

@app.get("/estabelecimento")
async def obterEstabelecimentos():
    # TODO: obter estabelecimentos do banco de dados
    return [
        {
            "id": 1,
            "cnpj": "98132323123",
            "descricao": "descrição aqui",
            "email": "email@email.com",
            "nome": "nome",
            "telefone": "(79)9 9999-9999"
        }
    ]

@app.post("/estabelecimento")
async def criarEstabelecimento(estabelecimento: Estabelecimento):
    if estabelecimento.id is None:
        #TODO: Enviar informações para serem adicionadas no banco de dados
        pass
    return estabelecimento

@app.put("/estabelecimento")
async def atualizarEstabelecimento(estabelecimento: Estabelecimento):
    if estabelecimento.id is None:
        return JSONResponse(status_code=400, content={'message': "Preencha os dados corretamente"})

    # TODO: atualizar dados do estabelecimento, no banco de acordo com id
    return {'message': "Estabelecimento Atualizado"}

@app.delete("/estabelecimento/{id}")
async def deletarEstabelecimento(id: int):
    # TODO: deletar o estabelecimento do ID solicitado
    return {'message': "Estabelecimento excluido"}


## =================================================================

@app.get("/servico")
async def obterServico():
    # TODO: obter servico do banco de dados
    return [
        {
            "id": 1,
            "nome": "kids club"
        },
        {
            "id": 2,
            "nome": "Espaço Familia"
        }
    ]

@app.post("/servico")
async def criarServico(servico: Servico):
    if servico.id is None:
        #TODO: Enviar informações para serem adicionadas no banco de dados
        pass
    return servico

@app.put("/servico")
async def atualizarServico(servico: Servico):
    if servico.id is None:
        return JSONResponse(status_code=400, content={'message': "Preencha os dados corretamente"})

    # TODO: atualizar dados do servico, no banco de acordo com id
    return {'message': "Serviço Atualizado"}

@app.delete("/servico/{id}")
async def deletarServico(id: int):
    # TODO: deletar o servico do ID solicitado
    return {'message': "Serviço excluido"}
