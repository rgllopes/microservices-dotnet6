using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public ProductRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);

        }
        public async Task<ProductVO> FindById(long id)
        {
            Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync() ?? new Product();
            return _mapper.Map<ProductVO>(product);
        }
        public async Task<ProductVO> Create(ProductVO vo)
        {
            //Converte ProductVO recebido para entidade Product
            Product product = _mapper.Map<Product>(vo);

            //Adiciona no contexto
            _context.Products.Add(product);
            
            //Função save propriamente dita
            await _context.SaveChangesAsync();

            //Retorna o resultado convertido de Product para ProductVO
            return _mapper.Map<ProductVO>(product);
        }
        public async Task<ProductVO> Update(ProductVO vo)
        {
            //Converte ProductVO recebido para entidade Product
            Product product = _mapper.Map<Product>(vo);

            //Adiciona no contexto
            _context.Products.Update(product);

            //Função save propriamente dita
            await _context.SaveChangesAsync();

            //Retorna o resultado convertido de Product para ProductVO
            return _mapper.Map<ProductVO>(product);
        }
        public async Task<bool> Delete(long id)
        {
            try
            {
                //Verifica se o id repassado existe na base de dados
                Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync() ?? new Product();

                //Se não existir retorna false
                if (product.Id <= 0)
                    return false;

                //Se existir persiste a alteração na base de dados
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }        
    }
}
