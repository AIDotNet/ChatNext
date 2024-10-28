using Microsoft.EntityFrameworkCore;

namespace ChatNext.EntityFrameworkCore.EntityFrameworkCore;

public class ChatNextDbContext(DbContextOptions<ChatNextDbContext> options) : DbContext(options)
{
    
}