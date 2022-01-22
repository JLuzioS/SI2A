using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace EntityFrameworkLayer
{
    public class EntityFramework : IDataBase
    {
        public int CreateFuncionario(ModelLayer.Funcionarios funcionario)
        {
            Funcionarios newFunc;
            using (var ctx = new L51NG3Entities())
            {
                newFunc  = new Funcionarios
                {
                    cc = funcionario.cc,
                    nif = funcionario.nif,
                    nome = funcionario.nome,
                    dtNascimento = funcionario.dtNascimento,
                    morada = funcionario.morada,
                    codigoPostal = funcionario.codigoPostal,
                    localidade = funcionario.localidade,
                    profissao = funcionario.profissao,
                    telefone = funcionario.telefone,
                    telemovel = funcionario.telemovel
                };
                ctx.Funcionarios.Add(newFunc);
                ctx.SaveChanges();
            }
            return newFunc.id;
        }

        public List<ModelLayer.Competencias> GetAllCompetencias()
        {
            using (var ctx = new L51NG3Entities())
            {
                var EFcompetencias = from allComp in ctx.Competencias select allComp;

                var ModelComp = new List<ModelLayer.Competencias>();

                foreach (var EFcomp in EFcompetencias)
                {
                    ModelComp.Add(Map(EFcomp));
                }

                return ModelComp;
            }
        }

        public void GetCompetencia(ModelLayer.Competencias c)
        {
            using (var ctx = new L51NG3Entities())
            {
                Competencias comp = new Competencias
                {
                    descricao = c.descricao
                };

                comp = ctx.Competencias.Add(comp);
                ctx.SaveChanges();
                c.id = comp.id;
            }
        }

        public void AddCompToFunc(ModelLayer.Funcionarios func, ModelLayer.Competencias comp)
        {
            using (var ctx = new L51NG3Entities())
            {
                var f = (from fun in ctx.Funcionarios where func.id == fun.id select fun).FirstOrDefault();

                if(f != null)
                {
                    f.Competencias.Add(new Competencias
                    {
                        id = comp.id,
                        descricao = comp.descricao
                    });
                }
                ctx.SaveChanges();
            }
        }

        private ModelLayer.Competencias Map(Competencias entityFrameWorkCompetencia)
        {
            return new ModelLayer.Competencias
            {
                id = entityFrameWorkCompetencia.id,
                descricao = entityFrameWorkCompetencia.descricao
            };
        }

        public List<ModelLayer.Funcionarios> GetAllFuncionarios()
        {
            using (var ctx = new L51NG3Entities())
            {
                var EFfuncionarios = from allFunc in ctx.Funcionarios select allFunc;

                var ModelFunc = new List<ModelLayer.Funcionarios>();

                foreach(var EFfunc in EFfuncionarios)
                {
                    ModelFunc.Add(Map(EFfunc));
                }

                return ModelFunc;
            }
        }

        public int GetFreeEquipa(int competenciaId)
        {
            using (var ctx = new L51NG3Entities())
            {
                return ctx.obtainCodigoDeEquipaLivre(competenciaId);
            }
        }

        public ModelLayer.Funcionarios Map(Funcionarios entityFrameWorkFuncionario)
        {
            return new ModelLayer.Funcionarios
            {
                cc = entityFrameWorkFuncionario.cc,
                nif = entityFrameWorkFuncionario.nif,
                nome = entityFrameWorkFuncionario.nome,
                dtNascimento = entityFrameWorkFuncionario.dtNascimento,
                morada = entityFrameWorkFuncionario.morada,
                codigoPostal = entityFrameWorkFuncionario.codigoPostal,
                localidade = entityFrameWorkFuncionario.localidade,
                profissao = entityFrameWorkFuncionario.profissao,
                telefone = entityFrameWorkFuncionario.telefone,
                telemovel = entityFrameWorkFuncionario.telemovel
            };
        }

        public List<ModelLayer.Intervencoes> GetAllIntervencoes()
        {
            using (var ctx = new L51NG3Entities())
            {
                List< ModelLayer.Intervencoes > result = new List< ModelLayer.Intervencoes >();
                foreach (var each in (from inter in ctx.Intervencoes select inter)) {
                    result.Add(new ModelLayer.Intervencoes
                    {
                        id = each.id,
                        competencias = each.competencias,
                        estado = each.estado,
                        activo = each.activo,
                        vlMonetario = each.vlMonetario,
                        dtInicio = each.dtInicio,
                        dtFim = each.dtFim,
                        perMeses = each.perMeses
                    });
                }
                return result;
            }
        }

        public int CreateEquipa(string localizacao, int numElementos)
        {
            using (var ctx = new L51NG3Entities())
            {
                ObjectParameter id = new ObjectParameter("id", typeof(Int32));
                ctx.insertEquipa(localizacao, numElementos, id);
                ctx.SaveChanges();
                return int.Parse(id.Value.ToString());
            }
        }

        

        public List<ModelLayer.Activos> GetAllActivos()
        {
            using (var ctx = new L51NG3Entities())
            {
                List<ModelLayer.Activos> result = new List<ModelLayer.Activos>();
                foreach (var each in (from activo in ctx.Activos select activo))
                {
                    result.Add(new ModelLayer.Activos
                    {
                        id = each.id,
                        nome = each.nome,
                        dtAaquisicao = each.dtAaquisicao,
                        estado = each.estado,
                        marca = each.marca,
                        modelo = each.modelo,
                        localizacao = each.localizacao, 
                        funcionario = each.funcionario,
                        tipo = each.tipo
                    });
                }
                return result;
            }
        }

        public ModelLayer.Activos GetActivo(int activo)
        {
            using (var ctx = new L51NG3Entities())
            {
                var result = (from activos in ctx.Activos where activos.id == activo select activos).FirstOrDefault();
                return new ModelLayer.Activos {
                    id = result.id,
                    nome = result.nome,
                    dtAaquisicao = result.dtAaquisicao,
                    estado = result.estado,
                    marca = result.marca,
                    modelo = result.modelo,
                    localizacao = result.localizacao,
                    funcionario = result.funcionario,
                    tipo = result.tipo
                };
            }
        }

        public bool AddFuncionario(ModelLayer.Equipas equipa, ModelLayer.Funcionarios funcionario)
        {
            using (var ctx = new L51NG3Entities())
            {
                ctx.insertFuncionariosEquipa(funcionario.id, equipa.id, DateTime.Now);
                return true;
            }
        }

        public int DeleteFuncionario(ModelLayer.Equipas equipa, ModelLayer.Funcionarios funcionario)
        {
            using (var ctx = new L51NG3Entities())
            {
                ObjectParameter numrows = new ObjectParameter("numrows", typeof(Int32));
                ctx.deleteFuncionariosEquipa(funcionario.id, equipa.id, DateTime.Now, numrows);
                return int.Parse(numrows.Value.ToString());
            }
        }

        public ModelLayer.Funcionarios GetFuncionarios(int idFuncionario)
        {
            using (var ctx = new L51NG3Entities())
            {
                var funcionarioEF = (from func in ctx.Funcionarios where func.id == idFuncionario select func).FirstOrDefault();

                if (funcionarioEF == null)
                {
                    throw new Exception("Funcionario nao encontrado");
                }

                return new ModelLayer.Funcionarios
                {
                    id = funcionarioEF.id,
                    cc = funcionarioEF.cc,
                    nif = funcionarioEF.nif,
                    nome = funcionarioEF.nome,
                    dtNascimento = funcionarioEF.dtNascimento,
                    morada = funcionarioEF.morada,
                    codigoPostal = funcionarioEF.codigoPostal,
                    localidade = funcionarioEF.localidade,
                    profissao = funcionarioEF.profissao,
                    telefone = funcionarioEF.telefone,
                    telemovel = funcionarioEF.telemovel
                };
            }
        }

        public ModelLayer.Equipas GetEquipas(int idEquipa)
        {
            using (var ctx = new L51NG3Entities())
            {
                var equipaEF = (from equipas in ctx.Equipas where equipas.id == idEquipa select equipas).FirstOrDefault();

                if (equipaEF == null)
                {
                    throw new Exception("Equipa nao encontrada");
                }

                return new ModelLayer.Equipas
                {
                    id = equipaEF.id,
                    localizacao = equipaEF.localizacao,
                    numElementos = equipaEF.numElementos,
                };
            }
        }

        public int CreateIntervencaoProcedure(ModelLayer.Intervencoes intervencoes)
        {
            using (var ctx = new L51NG3Entities())
            {
                ObjectParameter id = new ObjectParameter("id", typeof(Int32));
                ctx.p_CriaInter(intervencoes.competencias, intervencoes.activo, intervencoes.vlMonetario, intervencoes.dtInicio, intervencoes.perMeses, id);
                return int.Parse(id.Value.ToString());
            }
        }

        public bool AddEquipaToIntervencao(ModelLayer.IntervencoesEquipas intervencaoEquipa)
        {
            using (var ctx = new L51NG3Entities())
            {
                IntervencoesEquipas intervencoesEquipas = new IntervencoesEquipas
                {
                    equipa = intervencaoEquipa.equipa,
                    intervencao = intervencaoEquipa.intervencao,
                    dtAtribuicao = intervencaoEquipa.dtAtribuicao
                };

                var entity = ctx.IntervencoesEquipas.Add(intervencoesEquipas);

                if (entity == null)
                {
                    return false;
                }

                ctx.SaveChanges();
                return true;
            }
        }

        public bool UpdateIntervencaoState(ModelLayer.Intervencoes intervencoes)
        {
            using (var ctx = new L51NG3Entities())
            {
                var intervencaoEf = (from i in ctx.Intervencoes where intervencoes.id == i.id select i).FirstOrDefault();

                if (intervencaoEf == null)
                {
                    return false;
                }

                intervencaoEf.estado = intervencoes.estado;

                ctx.SaveChanges();
                return true;
            }
        }

        public bool CreateIntervencao(ModelLayer.Intervencoes intervencoes)
        {
            using (var ctx = new L51NG3Entities())
            {
                Intervencoes newFunc = new Intervencoes
                {
                    competencias = intervencoes.competencias,
                    estado = intervencoes.estado,
                    activo = intervencoes.activo,
                    vlMonetario = intervencoes.vlMonetario,
                    dtInicio = intervencoes.dtInicio,
                    dtFim = intervencoes.dtFim,
                    perMeses = intervencoes.perMeses
                };

                ctx.Intervencoes.Add(newFunc);
                ctx.SaveChanges();
                return true;
            }
        }

        List<ModelLayer.listAllIntervencoesFromDate_Result> IDataBase.GetALLIntervYear(string anoIntervencao)
        {
            using (var ctx = new L51NG3Entities())
            {
                List<ModelLayer.listAllIntervencoesFromDate_Result> result = new List<ModelLayer.listAllIntervencoesFromDate_Result>();
                foreach (var each in ctx.listAllIntervencoesFromDate(anoIntervencao))
                {
                    result.Add(new ModelLayer.listAllIntervencoesFromDate_Result
                    {
                        id = each.id,
                        descricao = each.descricao
                    });
                }
                return result;
            }
        }

        public void RemoveFuncionario(ModelLayer.Funcionarios func)
        {
            throw new NotImplementedException();
        }

        public void RemoveEquipa(ModelLayer.Equipas equipa)
        {
            throw new NotImplementedException();
        }

        public int ChangeFuncionarioCompetencia(ModelLayer.Funcionarios funcionario1, ModelLayer.Funcionarios funcionario2)
        {
            using (var ctx = new L51NG3Entities())
            {
                var funcionario1EF = (from fcomp in ctx.Funcionarios where fcomp.id == funcionario1.id select fcomp).FirstOrDefault();

                if (funcionario1EF == null)
                {
                    throw new Exception("Funcionario nao tem competencias associadas");
                }

                var funcionario2EF = (from fcomp in ctx.Funcionarios where fcomp.id == funcionario2.id select fcomp).FirstOrDefault();

                if (funcionario2EF == null)
                {
                    throw new Exception("Funcionario nao tem competencias associadas");
                }

                return 1;
            }
        }
    }
}
