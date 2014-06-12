from fabric.api import *


env.user = 'aksakal'
env.hosts = ['node1.fridge', 'node2.fridge']
env.password = 'wkC0qDkw%;'


def host_name():
    run('hostname')


def deploy():
    with cd('empty_fridge'):
        run('git pull')

    sudo("supervisorctl reload")
    sudo("service nginx restart")
